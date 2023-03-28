import json

from tkinter import *
from tkinter import scrolledtext
from tkinter.font import Font


def open_klient_panel():
    window_klient_panel = Tk()
    window_klient_panel.title("Панель клиента")
    window_klient_panel.attributes('-fullscreen', True)

    font2 = Font(family="Helvetica", size=50, weight="normal", slant="roman")

    main_label = Label(master=window_klient_panel, text="Очередь заказов", font=("Arial Bold", 50))
    main_label.pack(fill=X)

    frame_main = Frame(master=window_klient_panel)
    frame_main.pack(fill=X, padx=20, pady=20, expand=True)

    frame_left = Frame(master=frame_main, background='#DC143C')
    frame_left.pack(side=LEFT, fill=BOTH, expand=True)

    frame_left_left = Frame(master=frame_left)
    frame_left_left.pack(padx=20, pady=20, side=LEFT, fill=BOTH, expand=True)

    lbl_1 = Label(master=frame_left_left, text="Готовится", font=font2, background='#DC143C', foreground='white')
    lbl_1.pack(fill=X)

    txt_tab_1 = scrolledtext.ScrolledText(frame_left_left, relief=RIDGE)
    txt_tab_1.pack(fill=BOTH, expand=True)

    frame_right = Frame(master=frame_main, background='#006400')
    frame_right.pack(side=RIGHT, fill=BOTH, expand=True)

    frame_right_right = Frame(master=frame_right)
    frame_right_right.pack(padx=20, pady=20, side=RIGHT, fill=BOTH, expand=True)

    lbl_2 = Label(master=frame_right_right, text="Готово", font=font2, background='#006400', foreground='white')
    lbl_2.pack(fill=X)

    txt_tab_2 = scrolledtext.ScrolledText(frame_right_right, relief=RIDGE)
    txt_tab_2.pack(fill=BOTH, expand=True)

    def update_window():
        txt_tab_1.config(state='normal')
        txt_tab_2.config(state='normal')
        with open('BD.json', 'r', encoding='utf-8') as f:
            text = json.load(f)

        txt_tab_1.delete('1.0', END)
        txt_tab_2.delete('1.0', END)

        for txt in text['orders']:

            if txt['status']:
                txt_tab_2.insert(INSERT, f"{txt['id']} - {txt['dish']}\n")
            else:
                txt_tab_1.insert(INSERT, f"{txt['id']} - {txt['dish']}\n")

        window_klient_panel.after(1000, update_window)
        txt_tab_1.config(state='disabled')
        txt_tab_2.config(state='disabled')

    window_klient_panel.after(1000, update_window)

    window_klient_panel.mainloop()
