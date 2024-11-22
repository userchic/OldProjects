def prostoe (b):
    N=2
    i=2
    while i<b:
        if b%i==0:
            N=N+1
        i=i+1
    return N
a=1
while a!=0:
    a=int(input('введите любое целое число'))
    if prostoe (a)>2:
        print ('это число составное')
    else:
        print ('это число простое')
