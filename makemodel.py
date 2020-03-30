import cv2
import os
import numpy as np
import faceRecognition as fr

faces,faceID = fr.labels_for_training_data('/STUDY/Machine Learning/ProjekKehususan/TrainingImages')
# save data yang di training
face_recognizer = fr.train_classifier(faces,faceID)
face_recognizer.save('modelbaru.yml')

cv2.waitKey(0)#Waits indefinitely until a key is pressed
cv2.destroyAllWindows