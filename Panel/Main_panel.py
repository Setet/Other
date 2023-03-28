from tkinter import *

from Povar_panel import open_povar_panel
from Klient_panel import open_klient_panel


def main():
    window = Tk()
    window.state('zoomed')

    window.title("Панель выбора")

    frame_main = Frame(master=window)
    frame_main.pack(fill=X, padx=20, pady=20, expand=True)

    frame_left = Frame(master=frame_main, background='#DC143C')
    frame_left.pack(side=LEFT, fill=BOTH, expand=True)

    button = Button(master=frame_left, text="Повар", font=("Arial Bold", 50), relief=RIDGE, command=open_povar_panel)
    button.pack(side=TOP, fill=X)

    frame_right = Frame(master=frame_main, background='#006400')
    frame_right.pack(side=RIGHT, fill=BOTH, expand=True)

    button = Button(master=frame_right, text="Клиент", font=("Arial Bold", 50), relief=RIDGE, command=open_klient_panel)
    button.pack(side=TOP, fill=X)

    window.mainloop()


if __name__ == '__main__':
    main()
