import os

# mengambil nama folder untuk dicari id di database
idkelas = "null"
dir_path = os.path.dirname(os.path.realpath(__file__))
finalpath = dir_path.replace("\\","/") + "/TrainingImages"
# print(dir_path)
print(finalpath)

str1=dir_path.split('\\')
n=len(str1)
classname = str(str1[n-1])
print(classname)

classmodel = classname + ".yml"
print(classmodel)