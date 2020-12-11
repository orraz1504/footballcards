from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from playerc import player
from RT import Rplayer
import time
import sys
import os
import pyodbc

home_dir = os.path.expanduser('~')
desktop_dir = os.path.join(home_dir, 'Desktop')

path = "C:\crmdrv\chromedriver.exe"

"""
ad = driver.find_element_by_id("advertClose")
ad.send_keys(Keys.ENTER)

mytable = driver.find_element_by_css_selector('tbody')
for row in mytable.find_elements_by_css_selector('tr'):
    for col in row.find_elements_by_css_selector('td'):
        print (col.text)
"""


for c in range(26,29):
    options = webdriver.ChromeOptions() 
    options.add_experimental_option("excludeSwitches", ["enable-logging"])
    driver = webdriver.Chrome(options=options, executable_path=path)
    driver.get("https://www.futbin.com/21/players?page="+str(c)+"&league=13&sort=Player_Rating&order=desc")

    playernames=[]
    players=[]

    for t in driver.find_elements_by_class_name('player_name_players_table'):
        playernames.append(t.text)
        print(t.text)

    i=0
    for b in driver.find_elements_by_class_name('rating'):
        name = playernames[i]
        if b.text is not '':
            i+=1
            x=Rplayer(name, b.text)
            players.append(x)
            print(x.txtform())
    for i in players:
        conn = pyodbc.connect(r'Driver={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=C:\Users\User\Desktop\footballcards\footballtrading\website\App_Data\football.accdb;')
        cursor = conn.cursor()
        try:
            cursor.execute(r"UPDATE card SET [rating] = '"+i.rRating+"' WHERE [name] = '"+i.rname+"'")
            conn.commit()
        except:
            print(i.rname+" not in DB")
    print("end of page "+str(c))
    driver.close() 
    driver.quit()

