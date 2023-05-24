def main():
    import random

    # Создаем список персонажей с их классами
    characters = {
        'Ганер': ['Рикошет', 'Авто-пушка', 'Rocket-man', 'Пламя'],
        'Инжир': ['Дамаге', 'Турели', 'Аим-бот'],
        'Бурилка': ['Огонь', 'Лёд', 'Сопли'],
        'Скаут': ['Classic', 'Дед', 'Рокер-бой']
    }

    # Флаг для повторения выбора
    repeat_choice = True

    while repeat_choice:
        # Выбираем случайного персонажа
        random_character = random.choice(list(characters.keys()))

        # Выбираем случайный класс у выбранного персонажа
        random_class = random.choice(characters[random_character])

        # Выводим результат
        print('Выбран персонаж:', random_character)
        print('Выбран класс:', random_class)

        # Спрашиваем пользователя, хочет ли он повторить выбор
        user_choice = input('Хотите повторить выбор? (y/n) ')

        if user_choice.lower() == 'n':
            repeat_choice = False


if __name__ == '__main__':
    main()
