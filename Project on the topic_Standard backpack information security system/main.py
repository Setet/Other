# Функция остатка от деления
def mod(a, n):
    p = a // n
    r = (a - n * p)
    return r


# Функция переставляет элементы списка
def permute(t, tab_per):
    b = []
    for i in tab_per:
        b.append(t[i - 1])
    return b


# Функция вычисляет сумму произведений элементов двух списков
def knapsackSum(x, b):
    sum = 0
    a = []
    for i in range(len(b)):
        sum += (int(x[i]) * b[i])
        a.append(int(x[i]) * b[i])
    print(f"В рюкзаке: {set(a)}")
    return sum


# Функция находит представление числа через заданный набор чисел
def inv_knapsackSum(A, s1):
    x1 = []
    # print(A)
    for i in list(range(len(A) - 1, -1, -1)):
        if s1 >= A[i]:
            x1.append(1)
            s1 -= A[i]
        else:
            x1.append(0)
    return x1[::-1]


# Функция Эйлера от числа n
def fi(n):
    f = n
    if n % 2 == 0:
        while n % 2 == 0:
            n = n // 2
        f = f // 2
    i = 3
    while i * i <= n:
        if n % i == 0:
            while n % i == 0:
                n = n // i
            f = f // i
            f = f * (i - 1)
        i = i + 2
    if n > 1:
        f = f // n
        f = f * (n - 1)
    return f


A = [3, 5, 11, 21, 43, 87, 172, 350, 701, 1500]  # Закрытый ключ
n = 3002  # Секретный ключ
r = 27  # Секретный ключ
tab_per = [4, 2, 9, 5, 3, 10, 1, 7, 6, 8]  # Таблица перестановок

# Записываем cекретный ключи
f = open('secret_key_knapsack.txt', 'w')
f.write(f"A = {', '.join(map(str, A))}" + '\n')
f.write(f"n = {n}" + '\n')
f.write(f"r = {r}" + '\n')
f.close()

inv_r = mod(r ** (fi(n) - 1), n)  # Мультипликативная инверсия секретного ключа r
t = []  # Открытый ключ

message_man = "My name is Artem"  # Текст который мы шифруем

print("Шифрование: ")
for i in range(len(A)):
    t.append(mod(r * A[i], n))
print(f"Открытый ключ A: {t}")

b = permute(t, tab_per)  # Используем таблицу перестановки на наш открытый ключ
P = []  # Расшифрованный текст в ASCII
print("_____________________________________________")
for i in message_man:
    x = format(ord(i), f'0{len(tab_per)}b')  # Перевод символа в bit
    print(f"Символ '{i}' в ASCII bit: {x}")
    s = knapsackSum(x, b)  # Зашифрованный передаваемый символ
    print(f"Зашифрованный текст: {s} (сумма рюкзака)")
    print("Процесс расшифрования:")
    s1 = mod(inv_r * s, n)  # Вычисление s'
    print(f"s' = {s1} (остаток от деления мультипликативной инверсии секретного ключа, умноженного на зашифрованный "
          f"символ s делённого на n)")
    x1 = inv_knapsackSum(A, s1)  # Вычисление x'
    print(f"x' = {x1} (последовательность бит которую нужно переставить)")
    P_bit = permute(x1, tab_per)  # Применяем перестановку, чтобы узнать исх. посл. бит
    P.append(int('0b' + ''.join(map(str, P_bit)), 2))  # Переводим в DEC ASCII-код
    print(f"Расшифрованный текст в бит: {P_bit}")
    print("_____________________________________________")

print(f"Расшифрованный текст в ASCII: {P}")
Message_man_p = []  # Расшифрованный текст
for i in P:
    Message_man_p.append(chr(i))  # Перевод в char
print(f"Расшифрованный текст: {''.join(Message_man_p)}")
