from sklearn.model_selection import train_test_split
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.naive_bayes import MultinomialNB
from sklearn.metrics import accuracy_score
import sqlite3

# Открыть базу данных
conn = sqlite3.connect('articles.db')
# Получить курсор
c = conn.cursor()

# Выполнить запрос
c.execute('SELECT text, coincidences FROM articles')

# Занести результаты запроса в переменные
for row in c.fetchall():
    text, coincidences = row[4], row[2]

# Закрыть соединение
conn.close()

# Разделение данных на обучающий и тестовый наборы
X_train, X_test, y_train, y_test = train_test_split(text, coincidences, test_size=0.2, random_state=42)

# Векторизация текста с использованием TF-IDF
vectorizer = TfidfVectorizer()
X_train_tfidf = vectorizer.fit_transform(X_train)
X_test_tfidf = vectorizer.transform(X_test)

# Обучение модели наивного Байесовского классификатора
clf = MultinomialNB()
clf.fit(X_train_tfidf, y_train)

# Предсказание классов для тестового набора
y_pred = clf.predict(X_test_tfidf)

# Оценка точности классификации
accuracy = accuracy_score(y_test, y_pred)
print("Точность классификации:", accuracy)
