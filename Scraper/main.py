from flask import Flask, render_template
import requests
from bs4 import BeautifulSoup
import sqlite3

app = Flask(__name__)


def parser_articles(url):
    try:
        response = requests.get(url)
        soup = BeautifulSoup(response.text, 'html.parser')
        title = soup.find('meta', {'property': 'og:title'})['content']
        author = soup.find('a', {'class': 'tm-user-info__userpic'})['title']
        description = soup.find('meta', {'name': 'description'})['content'].strip()
        all_text = '\n'.join([p.text.strip() for p in soup.find_all('p')])

        return {
            'title': title,
            'author': author,
            'description': description,
            'text': all_text,
            'url': url,
            'coincidences': 'Художественная литература'
        }
    except Exception as e:
        print("Ошибка парсинга:", e)
        return None


def parser_web_sites(urls):
    href = []
    for url in urls:
        response = requests.get(url)
        soup = BeautifulSoup(response.text, 'html.parser')
        articles = soup.find_all('a', {'class': 'tm-title__link'})
        for article in articles:
            href.append('https://habr.com' + article.get('href'))
    return href


def create_table():
    conn = sqlite3.connect('articles.db')
    c = conn.cursor()
    c.execute('''CREATE TABLE IF NOT EXISTS articles
                 (id INTEGER PRIMARY KEY,
                  title TEXT,
                  author TEXT,
                  description TEXT,
                  text TEXT,
                  url TEXT,
                  coincidences TEXT)''')
    conn.commit()
    conn.close()


def insert_into(data):
    conn = sqlite3.connect('articles.db')
    c = conn.cursor()
    c.execute('''INSERT INTO articles (title, author,description, text, url, coincidences)
                 VALUES (?, ?, ?, ?, ?, ?)''',
              (data['title'],
               data['author'],
               data['description'],
               data['text'],
               data['url'],
               data['coincidences']))

    conn.commit()
    conn.close()


def delete_table_records(db_name, table_name):
    try:
        conn = sqlite3.connect(db_name)
        cursor = conn.cursor()
        cursor.execute(f"DELETE FROM {table_name}")

        conn.commit()
        cursor.close()
        conn.close()

        print(f"Все записи из таблицы '{table_name}' успешно удалены.")

    except sqlite3.Error as e:
        print(f"Ошибка при удалении записей из таблицы: {e}")


@app.route('/')
def index():
    base_url = 'https://habr.com/ru/feed/'
    page_numbers = range(1, 11)

    urls = [base_url + 'page' + str(page_number) for page_number in page_numbers]

    web_sites = parser_web_sites(urls)
    delete_table_records('articles.db', 'articles')

    create_table()
    for url in web_sites:
        data = parser_articles(url)
        if data:
            insert_into(data)

    conn = sqlite3.connect('articles.db')
    c = conn.cursor()
    c.execute('SELECT * FROM articles')
    rows = c.fetchall()
    conn.close()

    return render_template('index.html', data=rows)


if __name__ == '__main__':
    app.run(debug=True)
