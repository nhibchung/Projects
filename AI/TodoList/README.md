# TodoListProject

A simple Django todo app with optional Gradio integration.

## Setup

```powershell
python -m venv .venv
.\.venv\Scripts\Activate.ps1
pip install -r requirements.txt
py -3 manage.py migrate
```

## Run locally

Django app:
```powershell
py -3 manage.py runserver
```

Gradio wrapper (optional):
```powershell
python gradio_app.py
```

## Files

- `manage.py` — Django management
- `TodoListProject/` — project settings and ASGI/WGS entrypoints
- `TodoListApp/` — main app models, views, templates
- `app.py` — ASGI wrapper for deployment
- `gradio_app.py` — optional Gradio iframe wrapper
- `requirements.txt` — dependencies
- `.gitignore` — ignores virtual env, DB, and temp files

## GitHub

To publish:

```bash
git init
git add .
git commit -m "Initial commit"
git branch -M main
git remote add origin https://github.com/<username>/<repo>.git
git push -u origin main
```

## Notes

- `db.sqlite3` is ignored because it is local-only.
- For deployment, use `app.py` with an ASGI host or `manage.py` on a Django-ready host.
