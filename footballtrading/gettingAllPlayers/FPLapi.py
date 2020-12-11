import requests
import pyodbc

r = requests.get('https://fantasy.premierleague.com/api/bootstrap-static/')

data = r.json()

a = []

missing = []

conn = pyodbc.connect(r'Driver={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=C:\Users\User\Desktop\footballcards\footballtrading\website\App_Data\football.accdb;')
cursor = conn.cursor()
cursor.execute('select * from card')

count=0

for row in cursor.fetchall():
    a.append(row[1])


for player in data['elements']:
    pname = player['first_name'] + " "+ player['second_name'] 
    if pname not in a:
        count+=1
        print(pname)

print(count)
