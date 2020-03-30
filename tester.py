import cv2
import os
import numpy as np
import faceRecognition as fr


#This module takes images  stored in diskand performs face recognition
test_img=cv2.imread('/STUDY/Machine Learning/ProjekKehususan/TestImages/aji.jpeg')#test_img path
faces_detected,gray_img=fr.faceDetection(test_img)
print("faces_detected:",faces_detected)

# hanya deteksi wajah saja
# for (x,y,w,h) in faces_detected:
#     cv2.rectangle(test_img,(x,y),(x+w,y+h),(255,0,0),thickness=5)

# resized_img=cv2.resize(test_img,(1000,700))
# cv2.imshow("face detecetion tutorial",resized_img)
# cv2.waitKey(0)#Waits indefinitely until a key is pressed
# cv2.destroyAllWindows

# faces,faceID = fr.labels_for_training_data('/STUDY/Machine Learning/ProjekKehususan/TrainingImages')
# save data yang di training
# face_recognizer = fr.train_classifier(faces,faceID)
# face_recognizer.save('trainingData.yml')

# recognize menggunakan LBPH ambil dari data yg sudah di training di atas
face_recognizer = cv2.face.LBPHFaceRecognizer_create()
face_recognizer.read('/STUDY/Machine Learning/ProjekKehususan/trainingDataPK.yml')

# pelabelan id
name={0:"Alkaren",1:"Aji",2:"Aldred",3:"Wahid"}#creating dictionary containing names for each label

for face in faces_detected:
    (x,y,w,h)=face
    roi_gray=gray_img[y:y+h,x:x+h]
    label,confidence=face_recognizer.predict(roi_gray)#predicting the label of given image
    print("confidence:",confidence)
    print("label:",label)
    fr.draw_rect(test_img,face)
    predicted_name=name[label]
    if(confidence>60):#If confidence more than 37 then don't print predicted face text on screen
        continue
    fr.put_text(test_img,predicted_name,x,y)

resized_img=cv2.resize(test_img,(500,700))
cv2.imshow("face detecetion tutorial",resized_img)
cv2.waitKey(0)#Waits indefinitely until a key is pressed
cv2.destroyAllWindows