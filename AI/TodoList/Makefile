.PHONY: help install migrate makemigrations runserver createsuperuser shell static clean test lint

help:
	@echo "Available commands:"
	@echo "  make install           - Install project dependencies"
	@echo "  make migrate           - Apply database migrations"
	@echo "  make makemigrations    - Create new migrations"
	@echo "  make runserver         - Start development server on port 8000"
	@echo "  make createsuperuser   - Create a superuser account"
	@echo "  make shell             - Open Django shell"
	@echo "  make static            - Collect static files"
	@echo "  make clean             - Remove __pycache__, .pyc files, and db.sqlite3"
	@echo "  make test              - Run tests"

install:
	pip install -r requirements.txt

migrate:
	python manage.py migrate

makemigrations:
	python manage.py makemigrations

runserver:
	python manage.py runserver 8000

createsuperuser:
	python manage.py createsuperuser

shell:
	python manage.py shell

static:
	python manage.py collectstatic --noinput

clean:
	find . -type d -name __pycache__ -exec rm -rf {} +
	find . -type f -name "*.pyc" -delete
	rm -f db.sqlite3

test:
	python manage.py test

lint:
	flake8 . --exclude=migrations,venv
