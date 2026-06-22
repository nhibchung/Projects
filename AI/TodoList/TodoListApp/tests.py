from django.test import TestCase
from django.urls import reverse
from .models import Todo


class TodoModelTest(TestCase):
    def test_todo_string(self):
        todo = Todo.objects.create(title='Test todo', description='Test description')
        self.assertEqual(str(todo), 'Test todo')

    def test_mark_resolved_and_unresolved(self):
        todo = Todo.objects.create(title='Resolve test')
        self.assertFalse(todo.completed)
        todo.mark_resolved()
        self.assertTrue(todo.completed)
        todo.mark_unresolved()
        self.assertFalse(todo.completed)


class TodoViewTest(TestCase):
    def setUp(self):
        self.todo = Todo.objects.create(title='View test')

    def test_home_view(self):
        response = self.client.get(reverse('home'))
        self.assertEqual(response.status_code, 200)
        self.assertContains(response, 'Manage your todos')

    def test_todo_list_view(self):
        response = self.client.get(reverse('todo_list'))
        self.assertEqual(response.status_code, 200)
        self.assertContains(response, 'Create new todo')

    def test_todo_create_view(self):
        response = self.client.post(reverse('todo_create'), {
            'title': 'New todo',
            'description': 'New description',
            'completed': False,
        })
        self.assertEqual(response.status_code, 302)
        self.assertTrue(Todo.objects.filter(title='New todo').exists())

    def test_todo_update_view(self):
        response = self.client.post(reverse('todo_edit', args=[self.todo.pk]), {
            'title': 'Updated title',
            'description': 'Updated desc',
            'completed': True,
        })
        self.assertEqual(response.status_code, 302)
        self.todo.refresh_from_db()
        self.assertEqual(self.todo.title, 'Updated title')
        self.assertTrue(self.todo.completed)

    def test_todo_toggle_view(self):
        response = self.client.post(reverse('todo_toggle', args=[self.todo.pk]))
        self.assertEqual(response.status_code, 302)
        self.todo.refresh_from_db()
        self.assertTrue(self.todo.completed)

    def test_todo_delete_view(self):
        response = self.client.post(reverse('todo_delete', args=[self.todo.pk]))
        self.assertEqual(response.status_code, 302)
        self.assertFalse(Todo.objects.filter(pk=self.todo.pk).exists())
