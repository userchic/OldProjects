r=open("D:\\temp\\Габ\\russian words.txt","r")
e=open("D:\\temp\\Габ\\english words.txt","r")
s1=r.readlines ()
s2=e.readlines ()
print (s1)

i=0
mistakes=0
for line in s1:
   print (line)
for i in range (len (s1)):
    print (s1[i],"переведите слово на английский язык, введите перевод")
    strv=input()
    strv=strv+"\n"
    if strv==s2 [i]:
        print ("верно")
    else:
        print ("неверно")
        mistakes+=1
i=len(s1)
if mistakes/i>0.8:
    print ("оценка 5")
elif mistakes/i>0.6:
    print ("оценка 4")
elif mistakes/i>0.4:
    print ("оценка 3")
elif mistakes/i>0.2:
    print ("оценка 2")
elif mistakes/i<0.2:
    print ("оценка 1")
else:
    print ("оценка 0")
r.close ()
e.close ()
