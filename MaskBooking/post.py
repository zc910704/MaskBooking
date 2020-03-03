# -*- coding:utf-8 -*-
 
import requests
import json
import sys

def post(url, cookie, jsonStr):

    headers = {
    "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*":"q=0.8",
    "Accept-Language": "zh-CN,zh;q=0.9",
    "Cache-Control": "max-age=0",
    "Cookie": cookie,
    "Connection": "keep-alive",
    "Host": "kzgm.bbshjz.cn:8000",
    "User-Agent": "Mozilla/5.0 (Linux; U; Android 2.3.6; zh-cn; GT-S5660 Build/GINGERBREAD) AppleWebKit/533.1 (KHTML, like Gecko) Version/4.0 Mobile Safari/533.1 MicroMessenger/4.5.255",
    "Upgrade-Insecure-Requests": 1
    }


    response = requests.post(url, headers=headers, jsonStr)

    print(response.text)
 
if __name__=='__main__':
    post(sys.argv[1],sys.argv[2],sys.argv[3])