import json

from tkinter import *
from tkinter import scrolledtext
from tkinter.font import Font
from tkinter.messagebox import showinfo, askyesnocancel


def open_povar_panel():
    def cooking():
        for txt in text['orders']:

            if not txt['status']:
                result = askyesnocancel(title="Подтверждение операции", message="Уведомить о готовности ?")
                if result:
                    showinfo("Результат", "Готовность подтверждена")
                    txt_tab_2.config(state='normal')
                    txt_tab_2.insert(INSERT, f"{txt['id']} - {txt['dish']}\n")
                    txt_tab_1.config(state='normal')
                    txt_tab_1.delete(1.0, 2.0)
                    txt['status'] = True
                    with open('BD.json', 'w', encoding='utf-8') as f:
                        json.dump(text, f, ensure_ascii=False, indent=4)
                else:
                    showinfo("Результат", "Готовность отменена")
                break
        txt_tab_2.config(state='disabled')
        txt_tab_1.config(state='disabled')

    window_povar_panel = Tk()

    window_povar_panel.title("Панель повара")

    window_povar_panel.attributes('-fullscreen', True)

    font2 = Font(family="Helvetica", size=50, weight="normal", slant="roman")

    main_label = Label(master=window_povar_panel, text="Очередь заказов", font=("Arial Bold", 50))
    main_label.pack(fill=X)

    frame_main = Frame(master=window_povar_panel)
    frame_main.pack(fill=X, padx=20, pady=20, expand=True)

    frame_left = Frame(master=frame_main, background='#DC143C')
    frame_left.pack(side=LEFT, fill=BOTH, expand=True)

    frame_left_left = Frame(master=frame_left)
    frame_left_left.pack(padx=20, pady=20, side=LEFT, fill=BOTH, expand=True)

    lbl_1 = Label(master=frame_left_left, text="Принято", font=font2, background='#DC143C', foreground='white')
    lbl_1.pack(fill=X)

    button = Button(master=window_povar_panel, text="Готово", font=("Arial Bold", 50), relief=RIDGE, command=cooking)
    button.pack(side=TOP, fill=X)

    txt_tab_1 = scrolledtext.ScrolledText(frame_left_left, relief=RIDGE)
    txt_tab_1.pack(fill=BOTH, expand=True)

    frame_right = Frame(master=frame_main, background='#006400')
    frame_right.pack(side=RIGHT, fill=BOTH, expand=True)

    frame_right_right = Frame(master=frame_right)
    frame_right_right.pack(padx=20, pady=20, side=RIGHT, fill=BOTH, expand=True)

    lbl_2 = Label(master=frame_right_right, text="Готово", font=font2, background='#006400',
                  foreground='white')
    lbl_2.pack(fill=X)

    txt_tab_2 = scrolledtext.ScrolledText(frame_right_right, relief=RIDGE)
    txt_tab_2.pack(fill=BOTH, expand=True)

    with open('BD.json', 'r', encoding='utf-8') as file:
        text = json.load(file)

        for txt in text['orders']:

            if txt['status']:
                txt_tab_2.insert(INSERT, f"{txt['id']} - {txt['dish']}\n")
            else:
                txt_tab_1.insert(INSERT, f"{txt['id']} - {txt['dish']}\n")

    txt_tab_1.config(state='disabled')
    txt_tab_2.config(state='disabled')

    window_povar_panel.mainloop()
