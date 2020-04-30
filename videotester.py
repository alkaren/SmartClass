import os
import cv2
import numpy as np
import faceRecognition as fr
import pymysql
import datetime

# connection
connection=pymysql.connect(db='smartclassdb', user='root', passwd='', host='localhost', port=3307)
cursor = connection.cursor() 

cntup = 0

#This module captures images via webcam and performs face recognition
face_recognizer = cv2.face.LBPHFaceRecognizer_create()
# face_recognizer.read('/STUDY/Machine Learning/ProjekKehususan/trainingDataPK.yml')#Load saved training data
face_recognizer.read('/git/SmartClass/modelbaru.yml')#Load saved training data

name = {0 : "Alka",1 : "Aji",2 : "Aldred",3:"Wahid"}

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
        (x,y,w,h)=face
        roi_gray=gray_img[y:y+w, x:x+h]
        label,confidence=face_recognizer.predict(roi_gray)#predicting the label of given image
        print("confidence:",confidence)
        print("label:",label)
        fr.draw_rect(test_img,face)
        predicted_name=name[label]
        if confidence < 30 :#If confidence less than 37 then don't print predicted face text on screen
           fr.put_text(test_img,predicted_name,x,y)
           try:
              cntup += 1
              date_now = datetime.datetime.now().strftime("%Y-%m-%d")
              time_now = datetime.datetime.now().strftime("%H:%M:%S")
              print(date_now, time_now)
              sql = "INSERT INTO log_tbl (absen_log, nim, url_foto, tanggal_absen, start_time, last_time, total_time) VALUES(%s,%s,%s,%s,%s,%s,%s) ON DUPLICATE KEY UPDATE last_time= VALUES(last_time)"
              # sql = "INSERT INTO LOG_TBL(absen_log,NIM,url_foto) VALUES (%s,%s,%s)"
              cursor.execute(sql, (cntup, predicted_name, '~/BuktiAbsen/{0}.jpg'.format(predicted_name), date_now, time_now, time_now, '0'))
              connection.commit()
              cv2.imwrite("C:/Users/alkar/source/repos/TestSmartClass/TestSmartClass/BuktiAbsen/{0}.jpg".format(predicted_name), roi_gray)
           except :
             print("insert db failed")

    resized_img = cv2.resize(test_img, (1000, 700))
    cv2.imshow('face recognition tutorial ',resized_img)
    if cv2.waitKey(10) == ord('q'):#wait until 'q' key is pressed
        break


cap.release()
cv2.destroyAllWindows()

