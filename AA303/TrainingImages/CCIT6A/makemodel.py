import cv2
import os
import numpy as np
import faceRecognition as fr
import pymysql


# mengambil nama folder untuk dicari id di database
idkelas = "null"
dir_path = os.path.dirname(os.path.realpath(__file__))

# print(dir_path)
# print(finalpath)

str1=dir_path.split('\\')
n=len(str1)
classname = str(str1[n-1])
# print(classname)

finalpath = dir_path.replace("\\","/")
classmodel = classname + ".yml"
# print(classmodel)

save_path = dir_path.replace("\\","/")
print(finalpath)
print(save_path)

# connection
connection=pymysql.connect(db='smartclassdb', user='root', passwd='', host='localhost', port=3306)
cursor = connection.cursor() 

# mendapatkan id ruangan dari nama folder template
cursor.execute('UPDATE kelas_tbl SET usemodel =%s WHERE nama_kelas =%s',(save_path,classname))
connection.commit()

faces,faceID = fr.labels_for_training_data(finalpath)
# save data yang di training
face_recognizer = fr.train_classifier(faces,faceID)
face_recognizer.save(os.path.join(save_path,classmodel))


cv2.waitKey(0)#Waits indefinitely until a key is pressed
cv2.destroyAllWindows