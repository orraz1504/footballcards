from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from playerc import player
import time
import sys
import os
import pyodbc

home_dir = os.path.expanduser('~')
desktop_dir = os.path.join(home_dir, 'Desktop')

path = "C:\crmdrv\chromedriver.exe"

options = webdriver.ChromeOptions() 
options.add_experimental_option("excludeSwitches", ["enable-logging"])
driver = webdriver.Chrome(options=options, executable_path=path)
driver.get("https://www.premierleague.com/players?se=363&cl=11")
"""
ad = driver.find_element_by_id("advertClose")
ad.send_keys(Keys.ENTER)
"""
players=[]
club="Manchester City"
lastname="Liam Delap"
DidntWrite= True
mytable = driver.find_element_by_css_selector('tbody')
while DidntWrite:
    for row in mytable.find_elements_by_css_selector('tr'):
        try:
            nation = row.find_element_by_class_name('playerCountry')
            print(nation.text)
            name = row.find_element_by_class_name('playerName')
            print(name.text)
            filePath = str(row.find_element_by_class_name('img').get_attribute("src")).replace("40x40","250x250")
            print(filePath)
            pos = row.find_element_by_class_name('hide-s')
            print(pos.text)
            x=player(name.text, nation.text, club, filePath, pos.text)
            players.append(x)
            if(name.text == lastname):
                for i in players:
                    conn = pyodbc.connect(r'Driver={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=C:\Users\User\Desktop\footballcards\footballtrading\website\App_Data\football.accdb;')
                    cursor = conn.cursor()
                    try:
                        cursor.execute(r"insert INTO card ([name], [img], [country], [club], [pos], [type]) VALUES('"+ i.pname.replace("'","") +"','"+ i.pimg +"','"+i.pcountry+"','"+i.pclub+"','"+i.ppos+"','gold')")
                        conn.commit()
                    except:
                        print(i.pname+" not in DB")
                DidntWrite=False
                print("end")
                break
        except: 
            e = sys.exc_info()
            print(e)
            players = []
