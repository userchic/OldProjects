from pprint import pprint
from datetime import date
import os
def Check():
    try:
        cifra=int(input())
    except:
        print("Введён симбол, введите число ещё раз")
        cifra=Check()
    return cifra

def dateinput():
    try:
        date1=int(input("День:"))
        date2=int(input("Месяц:"))
        date3=int(input("Год:"))
        d=date(date3,date2,date1)
    except:
        print("день месяц или год введены неправильно, введите ещё раз")
        d=dateinput()
    return d
busparking=dict()
busparking["Автобусы"]=list()
busparking["Водители"]=list()
InputLine=""
id=1
while InputLine!="end.":
    os.system("CLS")
    InputLine=input('''               Меню
1 Добавить 
2 Отредактировать
3 Вывод
4 Удаление
out для вывода всей базы на экран
end. для завершения работы с программой
Ввод:''')
    if InputLine=="1":
        while InputLine!="end":
            os.system("CLS")
            print('''               Меню добавления
1 Добавить автобус
2 Добавить водителя
3 Добавить историю водителя
out для вывода всей базы на экран
end для возвращения к главному меню''')
            InputLine=input("Выбор:")
            if InputLine=="out":
                pprint(busparking)
                print("Enter для возвращения к меню")
                InputLine=input()
            if InputLine=='1':
                (busparking["Автобусы"]).append(dict())
                ((busparking["Автобусы"])[id-1])["id"]=int(id)
                print("Введите Гос. номер добавляемого автобуса:")
                ((busparking["Автобусы"])[id-1])["Гос. номер"]=Check()
                print("Введите маршрут добавляемого автобуса:")
                ((busparking["Автобусы"])[id-1])["Маршрут"]=Check()
                print("Введите дату ТО")
                ((busparking["Автобусы"])[id-1])["Дата ТО"]=dateinput()
                id+=1
            if InputLine=='2':
                (busparking["Водители"]).append(dict())
                ((busparking["Водители"])[len(busparking["Водители"])-1])["ФИО"]=str(input("Введите ФИО нового водителя"))
                ((busparking["Водители"])[len(busparking["Водители"])-1])["История"]=list()
            if InputLine=='3':
                if busparking["Водители"]!=list():
                    helpid=str(input("Введите ФИО водителя, для которого необходимо добавить историю"))
                k=0
                for item in busparking["Водители"]:
                    if item["ФИО"]==helpid:
                        k=1                
                        print("Введите id автобуса, на котором этот водитель был в этой истории")
                        helpid2=Check()
                        k1=0
                        for item in busparking["Автобусы"]:
                            if item["id"]==helpid2:
                                k1=1
                                (((busparking["Водители"])[helpid2-1])["История"]).append(dict())
                                (((busparking["Водители"])[helpid2-1])["История"])[len(((busparking["Водители"])[helpid2-1])["История"])-1]["id"]=helpid2
                                print("Дата выезда:")
                                (((busparking["Водители"])[helpid2-1])["История"])[len(((busparking["Водители"])[helpid2-1])["История"])-1]["Дата выезда"]=dateinput()
                                print("Дата сдачи смены:")
                                (((busparking["Водители"])[helpid2-1])["История"])[len(((busparking["Водители"])[helpid2-1])["История"])-1]["Дата сдачи смены"]=dateinput()
                        if k1==0:
                            print("Такого id у автобусов нет")
                if k==0:
                    print("Такого водителя нет в БД")
                else:
                    print("Водителей в базе ещё нет")
    if InputLine=="2":
        while InputLine!="end":
            os.system("CLS")
            InputLine=input('''               Меню редактирования
    Выберите значение, поле которого нужно отредактировать
1 Отредактировать автобус
2 Отредактировать водителя
3 Отредактировать историю водителя
out для вывода всей базы на экран
end для возвращения к главному меню''')
            if InputLine=="1":
                if busparking["Автобусы"]!=dict():
                    print("Введите id автобуса, который необходимо изменить:")
                    helpid=Check()
                    k=0
                    for item in busparking["Автобусы"]:
                        if item["id"]==helpid:
                            print('''               Меню редактирования
    Выберите поле автобуса, которое нужно отредактировать
1 Гос. номер автобуса
2 Маршрут автобуса
3 Дата ТО автобуса
Ввод:''')
                            k=1
                            InputLine="0"
                            while InputLine!="1" and InputLine!="2" and InputLine!="3":
                                InputLine=input("Выбор:")
                                if InputLine!="1" and InputLine!="2" and InputLine!="3":
                                    print("введено не 1 и не 2 и не 3")
                            if InputLine=="1":
                                item["Гос. номер"]=int(input("Введите новый гос. номер автобуса"))
                            if InputLine=="2":
                                item["Маршрут"]=int(input("Введите новый маршрут автобуса"))
                            if InputLine=="3":
                                item["Дата ТО"]=dateinput()
                    if k==0:
                        print("Такого id у автобусов нет")
                else:
                    print("Автобусов в базе ещё нет")
            if InputLine=="2":
                if busparking["Водители"]!=dict():
                    helpid=input("Введите ФИО водителя, которое необходимо изменить:")
                    k=0
                    for item in busparking["Водители"]:
                        if item["ФИО"]==helpid:
                            k=1
                            item["ФИО"]=input("Введите новое ФИО водителя")
                    if k==0:
                        print("Такого ФИО среди водителей нет")
                else:
                    print("Водителей в базе ещё нет")
            if InputLine=="3":
                if busparking["Водители"]!=dict():
                    helpid=input("Введите ФИО водителя, историю которого необходимо изменить:")
                    k=0
                    for item in busparking["Водители"]:
                        if item["ФИО"]==helpid:
                            k=1
                            helpid2=input("Введите id автобуса, на котором этот водитель был в этой истории")
                            for item in item:
                                if item["id"]==item:
                                    print("введите новую дату отправления и новую дату сдачи смены")
                                    print("Дата выезда")
                                    item["Дата выезда"]=dateinput()
                                    print("Дата сдачи смены")
                                    item["Дата сдачи смены"]=dateinput()
                    if k==0:
                        print("Такого автобуса среди автобусов нет")
                else:
                    print("Водителей в базе ещё нет")
            if InputLine=="out":
                pprint(busparking)
                print("Enter для возвращения к меню")
                InputLine=input()
    if InputLine=="3":
        while InputLine!="end":
            os.system("CLS")
            print('''                    Меню вывода
1 Вывод автобусов
2 Вывод водителей
out для вывода всей базы на экран
end. для завершения работы с программой''')
            InputLine=input("Выбор:")
            if InputLine=="1":
                if busparking["Автобусы"]!=list():  
                    print("Введите id автобуса, который необходимо вывести на экран")   
                    helpid=Check()  
                    k=0
                for item in busparking["Автобусы"]:
                        if item["id"]==helpid:
                            k=1
                            pprint(item)
                if k==0:    
                    print("Такого автобуса в базе нет")
            else:   
                print("Автобусов в базе ещё нет")
            if InputLine=="2":
                if busparking["Водители"]!=list():
                    helpid=str(input("Введите ФИО водителя, которого необходимо вывести на экран"))
                    k=0 
                    for item in busparking["Водители"]:
                        if item["ФИО"]==helpid:
                            k=1
                            pprint(item)
                    if k==0:
                        print("Такого Водителя в базе нет")
                else:
                    print("Водителей в базе ещё нет")
            if InputLine=="out":
                pprint(busparking)
                print("Enter для возвращения к меню")
                InputLine=input()
    if InputLine=="4":
        while InputLine!="end":
            os.system("CLS")
            print('''           Меню удаления
            1 Удалить автобус
            out для вывода всей базы на экран
            end для Возвращения к главному меню''')
            InputLine=input("Выбор:")
            if InputLine=="1":
                if busparking["Автобусы"]!=list():
                    print("Удалён автобус:")
                    pprint(((busparking["Автобусы"])[id-2]))
                    busparking["Автобусы"].pop(id-2)
                    id-=1
                else:
                    print("Автобусов в базе данных сейчас нет, удалять нечего")
            if InputLine=="out":
                pprint(busparking)
                print("Enter для возвращения к меню")
                InputLine=input()
    if InputLine=="out":
        pprint(busparking)
        print("Enter для возвращения к меню")
        InputLine=input()
                
    
