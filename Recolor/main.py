from PIL import Image, ImageTk
import numpy as np
from sklearn.cluster import KMeans
import tkinter as tk
from tkinter import filedialog
import tkinter.messagebox as mb


class ColorizeApp:
    def __init__(self, master):
        # Инициализация главного окна приложения
        self.master = master
        self.master.title("Раскраска изображения")

        # Инициализация переменных
        self.file_path = None
        self.n_colors = None
        self.output_image = None
        self.count_color = None

        # Создание кнопок и полей ввода
        self.button_select_file = tk.Button(self.master, text="Выберите изображение", command=self.select_file)
        self.button_select_file.pack(pady=10)

        self.label_select_colors = tk.Label(self.master, text="Выберите количество цветов:")
        self.label_select_colors.pack()

        self.entry_select_colors = tk.Entry(self.master)
        self.entry_select_colors.pack(pady=5)

        self.label_initial_colors = tk.Label(self.master, text="Количество цветов на фото:")
        self.label_initial_colors.pack()

        self.button_start = tk.Button(self.master, text="Раскрасить изображение", command=self.start)
        self.button_start.pack(pady=10)

        self.label_output_image = tk.Label(self.master)
        self.label_output_image.pack()

    def select_file(self):
        # Выбор файла изображения
        self.file_path = filedialog.askopenfilename()

        # Получение количества цветов начального фото
        initial_image = Image.open(self.file_path)
        pixels = initial_image.getdata()
        unique_colors = set(pixels)
        self.count_color = len(unique_colors)
        self.label_initial_colors.config(text=f"Количество цветов на фото: {self.count_color}")

        # Отображение выбранного изображения на форме
        image = initial_image.resize((400, 400), Image.ANTIALIAS)
        photo = ImageTk.PhotoImage(image)
        self.label_output_image.configure(image=photo)
        self.label_output_image.image = photo

    def start(self):
        # Получение количества цветов из поля ввода
        n_colors_str = self.entry_select_colors.get()
        self.n_colors = int(n_colors_str)

        if self.n_colors > self.count_color:
            msg = "Количество выбранных цветов больше,количества цветов на начальном изображении"
            mb.showerror("Ошибка", msg)
        else:
            # Цветовая раскраска изображения
            self.output_image = self.colorize_image(self.file_path, self.n_colors)

            # Сохранение нового файла с раскрашенным изображением в той же директории, где выбрано исходное
            output_file_path = filedialog.asksaveasfilename(defaultextension=".jpg", initialdir=self.file_path)
            self.output_image.save(output_file_path)

            # Отображение нового изображения на форме
            self.output_image = self.output_image.resize((400, 400), Image.ANTIALIAS)
            photo = ImageTk.PhotoImage(self.output_image)
            self.label_output_image.configure(image=photo)
            self.label_output_image.image = photo

    def colorize_image(self, file_path, n_colors):
        # Загрузка изображения
        img = Image.open(file_path)

        # Преобразование в матрицу numpy
        image_array = np.array(img)

        # Преобразование размерности матрицы
        h, w, c = image_array.shape
        image_array = image_array.reshape((h * w, c))

        # Поиск центров кластеров методом k-средних
        kmeans = KMeans(n_clusters=n_colors, random_state=0).fit(image_array)

        # Раскраска изображения в соответствии с центрами кластеров
        output_image_array = np.zeros_like(image_array)
        for i, center in enumerate(kmeans.cluster_centers_):
            output_image_array[kmeans.labels_ == i] = center

        # Преобразование матрицы обратно в изображение
        output_image_array = np.uint8(output_image_array.reshape((h, w, c)))
        output_image = Image.fromarray(output_image_array)

        return output_image


root = tk.Tk()
app = ColorizeApp(root)
root.geometry("500x500")
root.mainloop()
