def Check():
    try:
        cifra=int(input())
    except:
        print("введён симбол, введите число ещё раз")
        cifra=Check()
    return cifra
func1=[]
func2=[]
func3=[]
files=[]
print("Введите кол-во файлов в файловой системе")
N=Check()
if (N>0):
    i=0
    helputline=""
    str (helputline)
    InputLine=""
    str (InputLine)
    print("Введите названия файлов(с типом) и операции которые можно над ними выполнять")
    while i<N:
        InputLine=input()
        files.append("")
        files[i]=InputLine
        if InputLine[len(InputLine)-1]=="X" and InputLine[len(InputLine)-2]==" "  or InputLine[len(InputLine)-1]=="W" and InputLine[len(InputLine)-2]==" "  or InputLine[len(InputLine)-1]=="R" and InputLine[len(InputLine)-2]==" " :
            func1.append(InputLine[len(InputLine)-1])
            if InputLine[len(InputLine)-3]=="X" and InputLine[len(InputLine)-4]==" " or InputLine[len(InputLine)-3]=="W" and InputLine[len(InputLine)-4]==" " or InputLine[len(InputLine)-3]=="R" and InputLine[len(InputLine)-4]==" ":
                func2.append(InputLine[len(InputLine)-3])
                if InputLine[len(InputLine)-5]=="X" and InputLine[len(InputLine)-6]==" " or InputLine[len(InputLine)-5]=="W" and InputLine[len(InputLine)-6]==" " or InputLine[len(InputLine)-5]=="R" and InputLine[len(InputLine)-6]==" ":
                    func3.append(InputLine[len(InputLine)-5])
                    files[i]=InputLine[0:len(InputLine)-6]
                else:
                    func3.append("")
                    files[i]=InputLine[0:len(InputLine)-4]
            else:
                func2.append("")
                func3.append("")
                files[i]=InputLine[0:len(InputLine)-2]
        else:
            func2.append("")
            func3.append("")
            func1.append("")
            files[i]=InputLine[0:len(InputLine)]
        i+=1
    print("Введите кол-во операций которые необходимо выполнить над файлами(коварная программа только скажет можно ли их выполнять над этими файлами)")
    N=Check()
    print("Введите файлы с полным названием операций которые необходимо выполнить над ними(write file.txt)")
    i=0
    while i<N:
        InputLine=input()
        helputLine=InputLine[0:5:1]
        i+=1
        j=0
        if helputLine=="read ":
            if (InputLine[5:len(InputLine)]in files):
                j=files.index(InputLine[5:len(InputLine)])
                if func1[j]=="R" or func2[j]=="R" or func3[j]=="R":
                    print("OK")
                else:
                    print("Access denied")
            else:
                print("Такого файла нет")
        else:
            helputLine=InputLine[0:6:1]
            if helputLine=="write ":
                if (InputLine[6:len(InputLine)]in files):
                    j=files.index(InputLine[6:len(InputLine)])
                    if func1[j]=="W" or func2[j]=="W" or func3[j]=="W":
                        print("OK")
                    else:
                        print("Access denied")
                else:
                    print("Такого файла нет")
            else:
                helputLine=InputLine[0:3:1]
                if helputLine=="xx ":
                    if (InputLine[3:len(InputLine)]in files):
                        j=files.index(InputLine[3:len(InputLine)])
                        if func1[j]=="X" or func2[j]=="X" or func3[j]=="X":
                            print("OK")
                        else:
                            print("Access denied")
                    else:
                        print("Такого файла нет")
                else:
                    print("Не вижу команду")
print("Заверщение работы программы")