import random
def Check():
    try:
        cifra=int(input())
    except:
        print("введён симбол, введите число ещё раз")
        cifra=Check()
    return cifra
print("Для работы программы необходимо создать 2 списка чисел. Выберите способ создания списков:")
print("1 Ввод с доступного устройства ввода(клавиатура)")
print("2 Ввод с помощью генератора псевдослучайных чисел")
i=333
Line1 = []
Line2 = []
i=Check()
while i!=1 and i!=2:
    print("Вы ввели не 1 и не 2, введите ещё раз")
    i=Check()
if i==1:
    print("Ввод с клавиатуры")
    print("Введите длину строки 1")
    lenga1=Check()
    print("Введите строку 1: ")
    i=0
    while i<lenga1:
        Line1.append(Check())
        i+=1
    print("Введите длину строки 2")
    lenga2=Check()
    print("Введите строку 2: ")
    i=0
    while i<lenga2:
        Line2.append(Check())
        i+=1
if i==2:
    print("Ввод псевдослучайно")
    print("Введите длину строки 1")
    lenga1=Check()
    i=0
    print("Cтроку 1: ")
    while i<lenga1:
        Line1.append(random.randint(0,100))
        print (Line1[i])
        i+=1
    print("Введите длину строки 2")
    lenga2=Check()
    i=0
    print("Cтроку 2: ")
    while i<lenga2:
        Line2.append(random.randint(0,100))
        print (Line2[i])
        i+=1
i=max(min(Line1),min(Line2))
print("Числа принадлежащие обоим спискам:")
while i!=min(max(Line1),max(Line2)):
    if i in Line1 and i in Line2:
        print(i)
    i+=1