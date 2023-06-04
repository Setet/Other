import cv2
import numpy as np
import tkinter as tk
from tkinter import filedialog, colorchooser


def browse_file():
    global img_path
    img_path = filedialog.askopenfilename()


def change_color():
    global img_path
    img = cv2.imread(img_path)
    if img is None:
        print("Error: no image selected or invalid image format")
        return

    old_color = get_color(old_color_entry)
    new_color = get_color(new_color_entry)

    if old_color is None or new_color is None:
        print("Error: no color selected or invalid format")
        return

    old_color_arr = np.array(old_color)
    new_color_arr = np.array(new_color)

    mask = cv2.inRange(img, old_color_arr, old_color_arr)
    img[mask > 0] = new_color_arr

    cv2.imshow('Changed Image', img)
    cv2.waitKey(0)
    cv2.destroyAllWindows()


def get_color(entry):
    try:
        color = tuple(int(entry.get()[i:i + 2], 16) for i in (1, 3, 5))
        entry['bg'] = 'white'
        entry['fg'] = 'black'
    except:
        entry['bg'] = '#FFCFCF'
        entry['fg'] = 'black'
        color = None

    return color


def choose_old_color(entry):
    color = colorchooser.askcolor(title="Choose color")
    if color[1] is not None:
        entry.delete(0, tk.END)
        entry.insert(0, color[1])
        get_color(entry)


def choose_new_color(entry):
    color = colorchooser.askcolor(title="Choose color")
    if color[1] is not None:
        entry.delete(0, tk.END)
        entry.insert(0, color[1])
        get_color(entry)


app = tk.Tk()
app.title('Change Color on Photo')

img_path = None

old_color_entry = tk.Entry(app)
old_color_entry.insert(0, '#000000')
old_color_entry.grid(row=0, column=0)

old_color_button = tk.Button(app, text="Choose old color", command=lambda: choose_old_color(old_color_entry))
old_color_button.grid(row=0, column=1)

new_color_entry = tk.Entry(app)
new_color_entry.insert(0, '#FFFFFF')
new_color_entry.grid(row=1, column=0)

new_color_button = tk.Button(app, text="Choose new color", command=lambda: choose_new_color(new_color_entry))
new_color_button.grid(row=1, column=1)

browse_button = tk.Button(app, text="Browse", command=browse_file)
browse_button.grid(row=2, column=0)

change_button = tk.Button(app, text="Change", command=change_color)
change_button.grid(row=3, column=0)

app.geometry('300x150')
app.mainloop()
