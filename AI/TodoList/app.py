import os
import django
import gradio as gr
from datetime import datetime

os.environ.setdefault('DJANGO_SETTINGS_MODULE', 'TodoListProject.settings')
django.setup()

from TodoListApp.models import Todo


def get_todos():
    todos = Todo.objects.order_by('-created_at')
    return [
        [todo.pk, todo.title, todo.description or '', str(todo.due_date) if todo.due_date else '', 'Resolved' if todo.completed else 'Pending']
        for todo in todos
    ]


def parse_due_date(value):
    if not value:
        return None
    try:
        return datetime.fromisoformat(value).date()
    except ValueError:
        return None


def add_todo(title, description, due_date):
    if not title or not title.strip():
        return 'Title is required', get_todos()
    due = parse_due_date(due_date)
    if due_date and due is None:
        return 'Due date must be YYYY-MM-DD', get_todos()

    Todo.objects.create(
        title=title.strip(),
        description=description.strip() if description else '',
        due_date=due,
        completed=False,
    )
    return 'Todo added successfully!', get_todos()


def toggle_todo(todo_id):
    try:
        todo = Todo.objects.get(pk=int(todo_id))
        todo.completed = not todo.completed
        todo.save()
        status = 'resolved' if todo.completed else 'marked pending'
        return f'Todo {status}.', get_todos()
    except Exception as exc:
        return f'Error: {exc}', get_todos()


def delete_todo(todo_id):
    try:
        todo = Todo.objects.get(pk=int(todo_id))
        todo.delete()
        return 'Todo deleted.', get_todos()
    except Exception as exc:
        return f'Error: {exc}', get_todos()


def edit_todo(todo_id, title, description, due_date):
    try:
        todo = Todo.objects.get(pk=int(todo_id))
        if title and title.strip():
            todo.title = title.strip()
        todo.description = description.strip() if description else todo.description
        due = parse_due_date(due_date)
        if due_date and due is None:
            return 'Due date must be YYYY-MM-DD', get_todos()
        todo.due_date = due
        todo.save()
        return 'Todo updated.', get_todos()
    except Exception as exc:
        return f'Error: {exc}', get_todos()

with gr.Blocks(title='TodoListProject') as demo:
    gr.Markdown('# TodoListProject')
    gr.Markdown('Manage todos with the same data model as the Django app.')

    with gr.Row():
        with gr.Column():
            title_input = gr.Textbox(label='Title', placeholder='Enter todo title')
            desc_input = gr.Textbox(label='Description', placeholder='Enter description', lines=2)
            due_input = gr.Textbox(label='Due date (YYYY-MM-DD)', placeholder='Optional')
            create_btn = gr.Button('Create Todo', variant='primary')
        with gr.Column():
            todos_table = gr.Dataframe(value=get_todos(), headers=['ID', 'Title', 'Description', 'Due date', 'Status'], interactive=False)

    with gr.Row():
        with gr.Column():
            toggle_id = gr.Number(label='Toggle todo ID', precision=0)
            toggle_btn = gr.Button('Toggle Resolved', variant='secondary')
        with gr.Column():
            delete_id = gr.Number(label='Delete todo ID', precision=0)
            delete_btn = gr.Button('Delete Todo', variant='danger')

    with gr.Row():
        with gr.Column():
            edit_id = gr.Number(label='Edit todo ID', precision=0)
            edit_title = gr.Textbox(label='New title', placeholder='Leave blank to keep current')
            edit_description = gr.Textbox(label='New description', placeholder='Leave blank to keep current', lines=2)
            edit_due = gr.Textbox(label='New due date (YYYY-MM-DD)', placeholder='Optional')
            edit_btn = gr.Button('Update Todo', variant='secondary')

    status = gr.Textbox(label='Status', interactive=False)

    create_btn.click(add_todo, inputs=[title_input, desc_input, due_input], outputs=[status, todos_table])
    toggle_btn.click(toggle_todo, inputs=toggle_id, outputs=[status, todos_table])
    delete_btn.click(delete_todo, inputs=delete_id, outputs=[status, todos_table])
    edit_btn.click(edit_todo, inputs=[edit_id, edit_title, edit_description, edit_due], outputs=[status, todos_table])

if __name__ == '__main__':
    demo.launch(server_name='0.0.0.0', server_port=7860, share=False)
