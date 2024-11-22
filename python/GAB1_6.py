import random
enemies=('злой автобус','Василиса Прекрасная','Василиса ужасная','Василиса нормальная','Шрек','Осёл','Баба Яга','Торговец')
arsenal=['снотворное','ковёр самолёт','платье','золото','сено','Меч','Щит','Шапка-невидимка','живая вода','Осёл']
item1=random.choice (arsenal)
item2=random.choice (arsenal)
item3=random.choice (arsenal)
items=[item1,item2,item3]
en1=random.choice (enemies)
en2=random.choice (enemies)
en3=random.choice (enemies)
print ('Здравствуй, герой! Ты отправляешься в путь и у тебя есть следующий арсенал',item1,item2,'и',item3)
print ('на пути тебе встречается',en1)
if en1==enemies [0]:
    if arsenal [0] in items:
        print ('вы усыпили автобус и можете продолжать путь')
    elif arsenal [1] in items:
        print ('вы улетели от автобуса')
    else:
        print ('вы мертвы')
        break
if en1==enemies [1]:
    if arsenal [2] in items:
        print ('Василиса забирает платье и отдаёт вам случайную вещь')
        items.insert (3,random.choice (arsenal))
    elif arsenal [3] in items:
        print ('Василиса забирает золото у вас и вы продолжаете путь')
if en1==enemies [2]:
    if arsenal [2] in items:
        print ('Василиса забирает платье и отпускает вас')
        items.insert (3,random.choice (arsenal))
    elif arsenal [3] in items:
        print ('Василиса забирает золото у вас и вы продолжаете путь')
    else:
        print ('вы мертвы')
        break
if en1==enemies [3]:
    print ('Василиса нормальная дает вам случайную вещь и отпускает')
    items.insert (3,random.choice (arsenal))
if en1==enemies [4]:
    if arsenal [5] in items and arsenal [6] in items:
        print ('вы сразили Шрека и можете продолжатть путь')
    elif arsenal [5] in items and arsenal [8] in items:
        print ('вы сразили Шрека но он вас ранил. Воспользуйтесь живой водой')
    elif arsenal [9] in items:
        print ('вы отдаёте осла Шреку и можете продолжать путь')
    else:
        print ('вы мертвы')
        break
if en1==enemies [5]:
    if arsenal [9] in items:
        print ['вы кормите осла сеном и он решает присоединиться к вам']
        items.insert (3,arsenal [9])
if en1==enemies [6]:
    if arsenal [0] in items:
        print ('вы усыпили Бабу Ягу')
    if arsenal [1] in items:
        print ('вы улетеи от бабы Яги')
    if arsenal [7] in items: 
        print ('вы невидимы для Бабы Яги')
    else:
        print ('вы мертвы')
        break
if en1==enemies [7]:
    if arsenal [3] in items:
        print ('торговец продаёт вам случайную вещь')
        items.insert (3,random.choice (arsenal))
print ('на пути тебе встречается',en2)
if en2==enemies [0]:
    if arsenal [0] in items:
        print ('вы усыпили автобус и можете продолжать путь')
    elif arsenal [1] in items:
        print ('вы улетели от автобуса')
    else:
        print ('вы мертвы')
        break
if en2==enemies [1]:
    if arsenal [2] in items:
        print ('Василиса забирает платье и отдаёт вам случайную вещь')
        items.insert (3,random.choice (arsenal))
    elif arsenal [3] in items:
        print ('Василиса забирает золото у вас и вы продолжаете путь')
if en2==enemies [2]:
    if arsenal [2] in items:
        print ('Василиса забирает платье и отпускает вас')
        items.insert (3,random.choice (arsenal))
    elif arsenal [3] in items:
        print ('Василиса забирает золото у вас и вы продолжаете путь')
    else:
        print ('вы мертвы')
        break
if en2==enemies [3]:
    print ('Василиса нормальная дает вам случайную вещь и отпускает')
    items.insert (3,random.choice (arsenal))
if en2==enemies [4]:
    if arsenal [5] in items and arsenal [6] in items:
        print ('вы сразили Шрека и можете продолжатть путь')
    elif arsenal [5] in items and arsenal [8] in items:
        print ('вы сразили Шрека но он вас ранил. Воспользуйтесь живой водой')
    elif arsenal [9] in items:
        print ('вы отдаёте осла Шреку и можете продолжать путь')
    else:
        print ('вы мертвы')
        break
if en2==enemies [5]:
    if arsenal [9] in items:
        print ['вы кормите осла сеном и он решает присоединиться к вам']
        items.insert (3,arsenal [9])
if en2==enemies [6]:
    if arsenal [0] in items:
        print ('вы усыпили Бабу Ягу')
    elif arsenal [1] in items:
        print ('вы улетеи от бабы Яги')
    elif arsenal [7] in items: 
        print ('вы невидимы для Бабы Яги')
    else:
        print ('вы мертвы')
        break
if en2==enemies [7]:
    if arsenal [3] in items:
        print ('торговец продаёт вам случайную вещь')
        items.insert (3,random.choice (arsenal))
print ('на пути тебе встречается',en3)
if en3==enemies [0]:
    if arsenal [0] in items:
        print ('вы усыпили автобус и можете продолжать путь')
    elif arsenal [1] in items:
        print ('вы улетели от автобуса')
    else:
        print ('вы мертвы')
        break
if en3==enemies [1]:
    if arsenal [2] in items:
        print ('Василиса забирает платье и отдаёт вам случайную вещь')
        items.insert (3,random.choice (arsenal))
    elif arsenal [3] in items:
        print ('Василиса забирает золото у вас и вы продолжаете путь')
if en3==enemies [2]:
    if arsenal [2] in items:
        print ('Василиса забирает платье и отпускает вас')
        items.insert (3,random.choice (arsenal))
    elif arsenal [3] in items:
        print ('Василиса забирает золото у вас и вы продолжаете путь')
    else:
        print ('вы мертвы')
        break
if en3==enemies [3]:
    print ('Василиса нормальная дает вам случайную вещь и отпускает')
    items.insert (3,random.choice (arsenal))
if en3==enemies [4]:
    if arsenal [5] in items and arsenal [6] in items:
        print ('вы сразили Шрека и можете продолжатть путь')
    elif arsenal [5] in items and arsenal [8] in items:
        print ('вы сразили Шрека но он вас ранил. Воспользуйтесь живой водой')
    elif arsenal [9] in items:
        print ('вы отдаёте осла Шреку и можете продолжать путь')
    else:
        print ('вы мертвы')
        break
if en3==enemies [5]:
    if arsenal [9] in items:
        print ['вы кормите осла сеном и он решает присоединиться к вам']
        items.insert (3,arsenal [9])
if en3==enemies [6]:
    if arsenal [0] in items:
        print ('вы усыпили Бабу Ягу')
    elif arsenal [1] in items:
        print ('вы улетеи от бабы Яги')
    elif arsenal [7] in items: 
        print ('вы невидимы для Бабы Яги')
    else:
        print ('вы мертвы')
        break
if en3==enemies [7]:
    if arsenal [3] in items:
        print ('торговец продаёт вам случайную вещь')
        items.insert (3,random.choice (arsenal))
