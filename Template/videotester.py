import os
import cv2
import numpy as np
import faceRecognition as fr
import pymysql
import datetime

# mengambil nama folder untuk dicari id di database
idkelas = "null"
dir_path = os.path.dirname(os.path.realpath(__file__))
# print(dir_path)
strclass=dir_path.split('\\')
n=len(strclass)
roomname = str(strclass[n-1])
# print(roomname)

# connection
connection=pymysql.connect(db='smartclassdb', user='root', passwd='', host='localhost', port=3306)
cursor = connection.cursor() 

# mendapatkan id ruangan dari nama folder template
sqlruang = "SELECT id_ruang from ruangkuliah_tbl where nama_ruang=%s"
cursor.execute(sqlruang, roomname)
roomid = cursor.fetchall()
for x in roomid:
    idruang = x[0]
    # print(idkelas)

# get id class
datejdwl = datetime.datetime.now().strftime("%Y-%m-%d")
sqldir = "SELECT id_kelas from jadwal_tbl where id_ruang=%s and tanggal_jadwal=%s"
cursor.execute(sqldir, (idruang,datejdwl))
classid = cursor.fetchall()
for x in classid:
    idkelas = x[0]
    print(idkelas)

sqlnameclass = "SELECT nama_kelas,usemodel from kelas_tbl where id_kelas=%s"
cursor.execute(sqlnameclass, idkelas)
nameclass = cursor.fetchall()
for x in nameclass:
    namakelas = x[0]
    modelofuse = x[1]
    print(modelofuse)

#This module captures images via webcam and performs face recognition
face_recognizer = cv2.face.LBPHFaceRecognizer_create()
# face_recognizer.read('/STUDY/Machine Learning/ProjekKehususan/trainingDataPK.yml')#Load saved training data
pathmodel = modelofuse + "/" + namakelas + ".yml"
print(pathmodel)
face_recognizer.read(pathmodel)#Load saved training data

# menghitung jumlah mahasiswa yg berada dalam jadwal
sqlmhs = "SELECT COUNT(NIM) FROM mahasiswa_tbl WHERE id_kelas = %s"
cursor.execute(sqlmhs, idkelas)
jmlmhsw = cursor.fetchall()

# hitung jumlah folder training alias untuk menghitung jumlah siswa
countfolderpath = dir_path + "\\" + "TrainingImages" + "\\" + namakelas
filesX = foldersX = 0

for _, dirnames, filenames in os.walk(countfolderpath):
  # ^ this idiom means "we won't be using this value"
    filesX += len(filenames)
    foldersX += len(dirnames)

nums = foldersX
# print(nums)

# Create your dictionary class 
class my_dictionary(dict): 
  
    # __init__ function 
    def __init__(self): 
        self = dict() 
          
    # Function to add key:value 
    def add(self, key, value): 
        self[key] = value 
  
# Main Function 
dict_obj = my_dictionary()   

i = 0
# print(dict_obj)
if dict_obj == {}:
    # print("empty")
    while (i<nums):
        i = i+1
        sqlnims = "SELECT NIM FROM mahasiswa_tbl where id_kelas=%s and id=%s"
        cursor.execute(sqlnims, (idkelas,i))
        disctionrynew = cursor.fetchall()
        for x in disctionrynew:
            dict_obj.add(i, x[0])
            print(i)
            print(dict_obj)
else:
    print("no empty")

print(dict_obj)

# name = {1 : "Alka",2 : "Aji",3 : "Aldred",4:"Wahid"}
# source = 'http://192.168.1.7:8080//video?dummy=param.mjpg'
# cap=cv2.VideoCapture(0,cv2.CAP_DSHOW)
# cap=cv2.VideoCapture(0,cv2.CAP_DSHOW)
# cap=cv2.VideoCapture(source)
cap = cv2.VideoCapture("/git/SmartClass/VideoSampling/testvideo.mp4")

while True:
    ret,test_img=cap.read()# captures frame and returns boolean value and captured image
    faces_detected,gray_img=fr.faceDetection(test_img)



    for (x,y,w,h) in faces_detected:
      cv2.rectangle(test_img,(x,y),(x+w,y+h),(255,0,0),thickness=3)

    resized_img = cv2.resize(test_img, (1000, 700))
    # cv2.imshow('face detection Tutorial ',resized_img)
    cv2.waitKey(10)


    for face in faces_detected:
        
        date_now = datetime.datetime.now().strftime("%Y-%m-%d")
        time_now = datetime.datetime.now().strftime("%H:%M:%S")
        cntup = 0
        matkul = "null"
        nid = "null"

        cursor.execute("SELECT * FROM jadwal_tbl WHERE tanggal_jadwal=%s and id_kelas =%s", (date_now, idkelas))
        records = cursor.fetchall()
        for row in records:
            start = row[6]
            end = row[7]
            # x = datetime.datetime.strptime('09:30:00','%H:%M:%S').strftime('%H:%M:%S')
            # print(x)
            x = time_now
            if x >= start and x <= end:
                kelas = str(row[2])
                nid = str(row[3])
                matkul = str(row[4])
                print(row[2])
                print(row[3])
                print(row[4])
                break
            else:
                kelas = "null"
                matkul = "null"
                nid = "null"
                # print("null")
                continue
        
        (x,y,w,h)=face
        roi_gray=gray_img[y:y+w, x:x+h]
        label,confidence=face_recognizer.predict(roi_gray)#predicting the label of given image
        print("confidence:",confidence)
        print("label:",label)
        fr.draw_rect(test_img,face)
        predicted_name=dict_obj[label]
        if confidence < 30 :#If confidence less than 37 then don't print predicted face text on screen
           fr.put_text(test_img,predicted_name,x,y)
           try:
            if nid != "null" :
                cntup += 1
                print(date_now, time_now)
                sql = "INSERT INTO log_tbl (absen_log, nim, id_kelas, id_matkul, nid, url_foto, tanggal_absen, start_time, last_time) VALUES(%s,%s,%s,%s,%s,%s,%s,%s,%s) ON DUPLICATE KEY UPDATE last_time= VALUES(last_time)"
                # sql = "INSERT INTO LOG_TBL(absen_log,NIM,url_foto) VALUES (%s,%s,%s)"
                cursor.execute(sql, (cntup, predicted_name, kelas, matkul, nid, '~/BuktiAbsen/{0}.jpg'.format(predicted_name), date_now, time_now, time_now))
                connection.commit()
                cv2.imwrite("C:/Users/alkar/source/repos/TestSmartClass/TestSmartClass/BuktiAbsen/{0}.jpg".format(predicted_name), roi_gray)
            else:
                print("tidak ada jadwal")
           except :
             print("insert db failed")

    resized_img = cv2.resize(test_img, (1000, 700))
    cv2.imshow('face recognition tutorial ',resized_img)
    if cv2.waitKey(10) == ord('q'):#wait until 'q' key is pressed
        break


cap.release()
cv2.destroyAllWindows()

