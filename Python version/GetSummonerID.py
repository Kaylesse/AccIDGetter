import requests
import json
from xlrd import *
import xlwt
import time

API_Key = "RGAPI-cd9a1cb7-2258-47d7-a01e-dca06145f9db"
SummonerName = ""
matchHistoryURL = ""
accIDreversed = ""

book = open_workbook("Nazwy.xlsx")
book2 = xlwt.Workbook(encoding="utf-8")
sheet = book.sheet_by_index(0)
sheet1 = book2.add_sheet("Sheet 1")
sheet1.write(0, 0, "Summoner Name")
sheet1.write(0, 1, "Account ID")
dl = 20
col = sheet1.col(0)
col.width = 256*dl
col = sheet1.col(1)
col.width = 256*dl
i = 1
a = 1

for row in range(1, sheet.nrows):
    if(i==6*a + 1):
        time.sleep(26)
        a = a+1

    SummonerName = sheet.cell(row, 0).value
    # URL = "https://eun1.api.riotgames.com/lol/summoner/v3/summoners/by-name/" + SummonerName + "?api_key=" + API_Key
    URL = "https://eun1.api.riotgames.com/lol/summoner/v4/summoners/by-name/" + SummonerName + "?api_key=" + API_Key
    r = requests.get(URL)
    if r.status_code!=200:
        accID = "Konto nie istnieje"
        sheet1.write(i, 0, SummonerName)
        sheet1.write(i, 1, accID)
        i = i + 1
        continue
    json_data = json.loads(r.text)
    id = str(json_data["accountId"])
    URL2 = "https://eun1.api.riotgames.com/lol/match/v4/matchlists/by-account/"+ id + "?api_key=" + API_Key
    r2 = requests.get(URL2)
    json_data2 = json.loads(r2.text)
    matchid = str(json_data2["matches"][1]["gameId"])
    URL3 = "https://eun1.api.riotgames.com/lol/match/v4/matches/" + matchid + "?api_key=" + API_Key
    r3 = requests.get(URL3)
    json_data3 = json.loads(r3.text)
    tempgracze = json_data3["participantIdentities"]
    for x in tempgracze:
        nazwa = x["player"]["summonerName"]
        if nazwa==SummonerName:
            matchHistoryURL = x["player"]["matchHistoryUri"]
    reversedURL = matchHistoryURL[::-1]
    for c in reversedURL:
        if c=="/":
            break
        accIDreversed = accIDreversed + c
    accID = accIDreversed[::-1]
    sheet1.write(i, 0, SummonerName)
    sheet1.write(i, 1, accID)
    i = i+1
    print(SummonerName)
    print(accID)
    accIDreversed = ""
book2.save("Lista.xls")
