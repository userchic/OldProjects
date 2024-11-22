from pprint import pprint
import random
import os
def Check():
    try:
        cifra=int(input())
    except:
        print("введён симбол, введите число ещё раз")
        cifra=Check()
    return cifra
Supercars=dict()
keys=['minikuper','GAZ','lada','truck','kamaz','Лошадь','lowrider','Rhino','Ex-machine','turtle','Huanday','limuzin','БМП','Hammer','Megakuper']
InputLine="ы"
str (InputLine)
HelputLine="s"
str (HelputLine)
SupercarsList=[""]
while InputLine!="stop it!!!":
    if Supercars!=dict():
        print('''               Меню
       Действия которые может выполнить программа: 
1 Задать новые случайные значения словаря. 
2 Добавить элемент словаря вручную при помощи ввода пары ключ:значение. 
3 Вывести в консоль весь словарь при помощи pprint. 
4 Вывести ключи с наибольшим, наименьшим значением и общее среднее значение. 
5 Ввести ключ элемента, проверить наличие элемента в словаре без применения исключений. 
6 Приведите словарь к виду: 
7 Задать значение элемента по введенному ключу. 
8 Вывести на экран ключи с одинаковыми значениями.
clear
stop it!!! для выхода из программы''')
        InputLine=input("Выберите пункт Меню:")
        if InputLine=="clear":
            os.system("CLS")
        if InputLine=="1":
            Supercars['minikuper']=random.randint(1,10000)+random.random()
            Supercars['GAZ']=random.randint(1,10000)+random.random()
            Supercars['lada']=random.randint(1,10000)+random.random()
            Supercars['truck']=random.randint(1,10000)+random.random()
            Supercars['kamaz']=random.randint(1,10000)+random.random()
            Supercars['Лошадь']=random.randint(1,10000)+random.random()
            Supercars['lowrider']=random.randint(1,10000)+random.random()
            Supercars['Rhino']=random.randint(1,10000)+random.random()
            Supercars['Ex-machine']=random.randint(1,10000)+random.random()
            Supercars['turtle']=random.randint(1,10000)+random.random()
            Supercars['Huanday']=random.randint(1,10000)+random.random()
            Supercars['limuzin']=random.randint(1,10000)+random.random()
            Supercars['БМП']=random.randint(1,10000)+random.random()
            Supercars['Hammer']=random.randint(1,10000)+random.random()
            Supercars['Megakuper']=random.randint(1,10000)+random.random()
            print("Новые случайные значения заданы")
        elif InputLine=="2":
            HelputLine=input("Введите ключ, значение для которого нужно ввести в словарь")
            print("Введите значение соответствующее этому элементу, вводимому в словарь")
            if HelputLine in keys and HelputLine not in Supercars.keys():
                if keys.index(HelputLine)==0:
                    Supercars['minikuper']=int(input())
                elif keys.index(HelputLine)==1:
                    Supercars['GAZ']=int(input())
                elif keys.index(HelputLine)==2:
                    Supercars['lada']=int(input())
                elif keys.index(HelputLine)==3:
                    Supercars['truck']=int(input())
                elif keys.index(HelputLine)==4:
                    Supercars['kamaz']=int(input())
                elif keys.index(HelputLine)==5:
                    Supercars['Лошадь']=int(input())
                elif keys.index(HelputLine)==6:
                    Supercars['lowrider']=int(input())
                elif keys.index(HelputLine)==7:
                    Supercars['Rhino']=int(input())
                elif keys.index(HelputLine)==8:
                    Supercars['Ex-machine']=int(input())
                elif keys.index(HelputLine)==9:
                    Supercars['turtle']=int(input())
                elif keys.index(HelputLine)==10:
                    Supercars['Huanday']=int(input())
                elif keys.index(HelputLine)==11:
                    Supercars['limuzin']=int(input())
                elif keys.index(HelputLine)==12:
                    Supercars['БМП']=int(input())
                elif keys.index(HelputLine)==13:
                    Supercars['Hammer']=int(input())
                elif keys.index(HelputLine)==14:
                    Supercars['Megakuper']=int(input())
                else:
                    print("Введённый ключ отсутствует в заранее созданном списке ключей, либо уже присутствует в словаре")
        elif InputLine=="3":
            print()
            pprint (Supercars)
            print()
        elif InputLine=="4":
            k=0
            maximum=0
            float (maximum)
            minimum=999999999999
            float (minimum)
            strmaximum="ы"
            strminimum="ы"
            sumval=0
            float (sumval)
            maximum=0
            for key,value in Supercars.items():
                k+=1
                sumval+=value
                if value>maximum:
                    strmaximum=key
                    maximum=value
                if value<minimum:
                    strminimum=key
                    minimum=value
            print("Минимальное значение словаря=",minimum,"Ключ: ",strminimum," Максимальное значение=",maximum,"Ключ:",strmaximum,"среднее значение равно ",sumval/k)
        elif InputLine=="5":
                    InputLine=input("Введите ключ, наличие которого необходимо проверить. Он будет удалён. ")
                    if InputLine in Supercars:
                        Supercars.pop(InputLine)
                    else:
                        print("Такой ключ отсутствует в словаре")
        elif InputLine=="6":
            Supercars2={}
            for key,value in Supercars.items():
                print ("Введите значение мощности автомобиля",key,"  : ")
                Supercars2[key]=float(input())
            SupercarsLine=[Supercars,Supercars2]
            print ("Полученный список словарей имеет вид")
            print (SupercarsLine)
            print("Идёт сортировка...")
            Helpcars=dict()
            maximum=0
            ki=[]
            va=[]
            for key,value in Supercars.items():
                ki.append(key)
                va.append(value)
            while len(Helpcars)!=len(Supercars):
                maximum=0
                for value in va:
                    if value>maximum:
                        maximum=value
                Helpcars[ki[va.index(maximum)]]=maximum
                ki.pop(va.index(maximum))
                va.pop(va.index(maximum))   
            Supercars=Helpcars
            Helpcars=dict()    
            maximum=0        
            ki=[]
            va=[]
            for key,value in Supercars2.items():
                ki.append(key)
                va.append(value)
            while len(Helpcars)!=len(Supercars2):
                maximum=0  
                for value in va:
                    if value>maximum:
                        maximum=value
                Helpcars[ki[va.index(maximum)]]=maximum
                ki.pop(va.index(maximum))
                va.pop(va.index(max(va))) 
            Supercars2=Helpcars
            SupercarsLine=[Supercars,Supercars2]
            print("Отсортированный список словарей:")
            print (SupercarsLine)
        elif InputLine=="7":
            HelputLine=input("Введите ключ, словарьное значение для которого нужно изменить")
            print("Введите значение которое необходимо присвоить этому элементу")
            if HelputLine in Supercars.keys() and HelputLine in keys:
                if keys.index(HelputLine)==0:
                    Supercars['minikuper']=int(input())
                elif keys.index(HelputLine)==1:
                    Supercars['GAZ']=int(input())
                elif keys.index(HelputLine)==2:
                    Supercars['lada']=int(input())
                elif keys.index(HelputLine)==3:
                    Supercars['truck']=int(input())
                elif keys.index(HelputLine)==4:
                    Supercars['kamaz']=int(input())
                elif keys.index(HelputLine)==5:
                    Supercars['Лошадь']=int(input())
                elif keys.index(HelputLine)==6:
                    Supercars['lowrider']=int(input())
                elif keys.index(HelputLine)==7:
                    Supercars['Rhino']=int(input())
                elif keys.index(HelputLine)==8:
                    Supercars['Ex-machine']=int(input())
                elif keys.index(HelputLine)==9:
                    Supercars['turtle']=int(input())
                elif keys.index(HelputLine)==10:
                    Supercars['Huanday']=int(input())
                elif keys.index(HelputLine)==11:
                    Supercars['limuzin']=int(input())
                elif keys.index(HelputLine)==12:
                    Supercars['БМП']=int(input())
                elif keys.index(HelputLine)==13:
                    Supercars['Hammer']=int(input())
                elif keys.index(HelputLine)==14:
                    Supercars['Megakuper']=int(input())
        elif InputLine=="8":
            difvalues=list()
            equvalues=list()
            print("Ключи с одинаковыми значениями :")
            for key,value in Supercars.items():
                if value in difvalues:
                    equvalues.append(value)
                else:
                    difvalues.append(value)
            if len(difvalues)==15:
                print("Ненайдено ключей с одинаковыми значениями")
            else:
                for key,value in Supercars.items():
                    if value in equvalues:
                        print (key," ",value)
        elif InputLine=="stop it!!!":
            print("Окончание работы программы.......")
    if Supercars==dict():
        print('''               Меню 
Действия которые может выполнить программа: 
1. Задать новые случайные значения словаря. 
2. Добавить элемент словаря вручную при помощи ввода пары ключ:значение.''')
        InputLine=input("Выберите пункт Меню:")
        if InputLine=="1":
            Supercars['minikuper']=random.randint(1,10000)+random.random()
            Supercars['GAZ']=random.randint(1,10000)+random.random()
            Supercars['lada']=random.randint(1,10000)+random.random()
            Supercars['truck']=random.randint(1,10000)+random.random()
            Supercars['kamaz']=random.randint(1,10000)+random.random()
            Supercars['Лошадь']=random.randint(1,10000)+random.random()
            Supercars['lowrider']=random.randint(1,10000)+random.random()
            Supercars['Rhino']=random.randint(1,10000)+random.random()
            Supercars['Ex-machine']=random.randint(1,10000)+random.random()
            Supercars['turtle']=random.randint(1,10000)+random.random()
            Supercars['Huanday']=random.randint(1,10000)+random.random()
            Supercars['limuzin']=random.randint(1,10000)+random.random()
            Supercars['БМП']=random.randint(1,10000)+random.random()
            Supercars['Hammer']=random.randint(1,10000)+random.random()
            Supercars['Megakuper']=random.randint(1,10000)+random.random()
            print("Новые случайные значения заданы")
        elif InputLine=="2":
            HelputLine=input("Введите ключ, значение для которого нужно ввести в словарь")
            print("Введите значение соответствующее этому элементу, вводимому в словарь")
            if HelputLine in keys:
                if keys.index(HelputLine)==0:
                    Supercars['minikuper']=int(input())
                elif keys.index(HelputLine)==1:
                    Supercars['GAZ']=int(input())
                elif keys.index(HelputLine)==2:
                    Supercars['lada']=int(input())
                elif keys.index(HelputLine)==3:
                    Supercars['truck']=int(input())
                elif keys.index(HelputLine)==4:
                    Supercars['kamaz']=int(input())
                elif keys.index(HelputLine)==5:
                    Supercars['Лошадь']=int(input())
                elif keys.index(HelputLine)==6:
                    Supercars['lowrider']=int(input())
                elif keys.index(HelputLine)==7:
                    Supercars['Rhino']=int(input())
                elif keys.index(HelputLine)==8:
                    Supercars['Ex-machine']=int(input())
                elif keys.index(HelputLine)==9:
                    Supercars['turtle']=int(input())
                elif keys.index(HelputLine)==10:
                    Supercars['Huanday']=int(input())
                elif keys.index(HelputLine)==11:
                    Supercars['limuzin']=int(input())
                elif keys.index(HelputLine)==12:
                    Supercars['БМП']=int(input())
                elif keys.index(HelputLine)==13:
                    Supercars['Hammer']=int(input())
                elif keys.index(HelputLine)==14:
                    Supercars['Megakuper']=int(input())