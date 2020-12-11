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
    if row[7] in a:
        print(str(row[7])+" is dupe\n")
    else:
        a.append(row[7])



"""
for player in data['elements']:
    pname = player['web_name']
    for i in range(len(a)):
        if a[i] in pname:
                cursor.execute(r"UPDATE card SET [TestId] = "+ str(player['id'])+" WHERE [name] = '"+a[i]+"'")
                conn.commit()
                count+=1
                print(a[i]+"added")
"""
print(count)
