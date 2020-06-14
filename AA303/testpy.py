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
sqlruang = "SELECT id_ruangan from ruangkuliah_tbl where id_ruang=%s"
cursor.execute(sqlruang, roomname)
roomid = cursor.fetchall()
for x in roomid:
    idruang = x[0]
    # print(idkelas)

# get id class
sqldir = "SELECT id_kelas from jadwal_tbl where id_ruang=%s"
cursor.execute(sqldir, idruang)
classid = cursor.fetchall()
for x in classid:
    idkelas = x[0]
    # print(idkelas)

#This module captures images via webcam and performs face recognition
face_recognizer = cv2.face.LBPHFaceRecognizer_create()
# face_recognizer.read('/STUDY/Machine Learning/ProjekKehususan/trainingDataPK.yml')#Load saved training data
pathmodel = dir_path.replace("\\","/") + "/" + roomname + ".yml"
print(pathmodel)
face_recognizer.read(pathmodel)#Load saved training data

# menghitung jumlah mahasiswa yg berada dalam jadwal
sqlmhs = "SELECT COUNT(NIM) FROM mahasiswa_tbl WHERE id_kelas = %s"
cursor.execute(sqlmhs, idkelas)
jmlmhsw = cursor.fetchall()

# hitung jumlah folder training alias untuk menghitung jumlah siswa
countfolderpath = dir_path + "\TrainingImages"
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
        dict_obj.add(i, 'Geeks')
        i = i+1
        # print(i)
        # print(dict_obj)
else:
    print("no empty")

print(dict_obj)
print(jmlmhsw)