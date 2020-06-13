import cv2
import os
import numpy as np
import faceRecognition as fr

# mengambil nama folder untuk dicari id di database
idkelas = "null"
dir_path = os.path.dirname(os.path.realpath(__file__))
finalpath = dir_path.replace("\\","/") + "/TrainingImages"
# print(dir_path)
# print(finalpath)

str1=dir_path.split('\\')
n=len(str1)
classname = str(str1[n-1])
# print(classname)

classmodel = classname + ".yml"
# print(classmodel)

save_path = dir_path.replace("\\","/")

faces,faceID = fr.labels_for_training_data(finalpath)
# save data yang di training
face_recognizer = fr.train_classifier(faces,faceID)
face_recognizer.save(os.path.join(save_path,classmodel))

cv2.waitKey(0)#Waits indefinitely until a key is pressed
cv2.destroyAllWindows