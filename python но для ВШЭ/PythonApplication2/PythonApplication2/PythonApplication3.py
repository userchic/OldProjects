def Check():
    try:
        cifra=int(input())
    except:
        print("введён симбол, введите число ещё раз")
        cifra=Check()
    return cifra
f=open('results.txt','w')
name="ыкса"
str (name)
print ("Введите имена и результаты игроков, ввод имени игрока как пустота закончит работу программы, информация будет выведена в файл results")
while name!="":
    name=str(input())
    if name!="":
        score=Check()
        print(name,':',score,file==f)
print("Завершение работы программы...")