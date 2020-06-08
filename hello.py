import pymysql
import datetime

date_now = datetime.datetime.now().strftime("%Y-%m-%d")
time_now = datetime.datetime.now().strftime("%H:%M:%S")

# connection
connection=pymysql.connect(db='smartclassdb', user='root', passwd='', host='localhost', port=3307)
cursor = connection.cursor() 

sqljadwal = "SELECT * FROM jadwal_tbl WHERE tanggal_jadwal=%s and idkelas = 'C1'"
cursor.execute(sqljadwal, date_now)
records = cursor.fetchall()
for row in records:
    start = row[6]
    end = row[7]
    # x = datetime.datetime.strptime('09:30:00','%H:%M:%S').strftime('%H:%M:%S')
    # print(x)
    x = time_now
    if x >= start and x <= end:
        print(row[3])
        print(row[4])
        break
    else:
        print("null")
        continue

