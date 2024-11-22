import random
chislo=""
chislo1=""
cows=0
byki=0
for i in range (4):
    C1=str(random.randint (0,9))
    while C1 in chislo:
        C1=random.randint (0,9)
    chislo+=(C1)
    if C1==chislo1 [i]:
        byki+=1
for i in range (4):
    if chislo1 [1] in chislo:
        cows+=1
if chislo==chislo1:
    print (угадал)
else:
    print (byki,"быка и",cows,"коров")
