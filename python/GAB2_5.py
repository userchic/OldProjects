import random
chislo=0
N=0
for i in range (6):
    C1=str(random.randint (1,36))
    while C1 in chislo:
        C1=str(input())
    chislo+=C1
    print ("я загадал 6 чисел в промежутке от 1 до 36, попробуйте угадать их")
for i in range (6):
    C2=str(input())
    if C2 in chislo:
        N+=1
if N==0:
    print("неудача")
if N==1:
    print("Вы невезунчик")
if N==2:
    print("Увы")
if N==3:
    print("повезёт в следующий раз")
if N==4:
    print("отличный результат")
if N==5:
    print("Почти!")
if N==6:
    print("БИНГО!!")
    
