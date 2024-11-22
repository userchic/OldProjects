import random
enemies=('злой автобус','Василиса Прекрасная','Василиса ужасная','Василиса нормальная','Шрек','Осёл','Баба Яга','Торговец')
arsenal=['снотворное','ковёр самолёт','платье','золото','сено','Меч','Щит','Шапка-невидимка','живая вода','Осёл']
item1=random.choice (arsenal)
item2=random.choice (arsenal)
item3=random.choice (arsenal)
items=[item1,item2,item3]
en1=enemies [1]
en2=random.choice (enemies)
en3=random.choice (enemies)
print (items)
if en1==enemies [1]:
    if arsenal [1] in items:
        print ('вы усыпили автобус и можете продолжать путь')
        del items [arsenal [1]] 
print (items)
