import cv2
import os
import numpy as np
import faceRecognition as fr
import pymysql

# connection
connection=pymysql.connect(db='smartclassdb', user='root', passwd='', host='localhost', port=3306)
cursor = connection.cursor() 

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


# mendapatkan id ruangan dari nama folder template
sqlmodel = "UPDATE kelas_tbl set usemodel = '%s' WHERE id_kelas = '%s'"
cursor.execute(sqlmodel, (save_path,classname))
connection.commit()
