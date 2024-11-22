def summa (d):
    s=0
    while d>0:
        ost=d%10
        s=s+ost
        d=d//10
    return s
def maximin (b):
    m1=0
    m2=b%10
    while b!=0:
        ost=b%10
        if ost >m1:
            m1=ost
        if ost<m2:
            m2=ost
        b=b//10
        m=[m1,m2]
    return m
def display (c,s,m):
    print (c,s,m [0],m [1])
for i in range (5):
     a=int(input("введите число"))
     display (a,summa (a),maximin (a))
