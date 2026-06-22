from django.shortcuts import get_object_or_404, redirect
from django.urls import reverse_lazy
from django.views.generic import ListView, CreateView, UpdateView, DeleteView, TemplateView

from .models import Todo
from .forms import TodoForm


class HomeView(TemplateView):
    template_name = 'home.html'


class TodoListView(ListView):
    model = Todo
    template_name = 'todo_list.html'
    context_object_name = 'object_list'


class TodoCreateView(CreateView):
    model = Todo
    form_class = TodoForm
    template_name = 'todo_form.html'
    success_url = reverse_lazy('todo_list')


class TodoUpdateView(UpdateView):
    model = Todo
    form_class = TodoForm
    template_name = 'todo_form.html'
    success_url = reverse_lazy('todo_list')


class TodoDeleteView(DeleteView):
    model = Todo
    template_name = 'todo_confirm_delete.html'
    success_url = reverse_lazy('todo_list')


def todo_toggle(request, pk):
    todo = get_object_or_404(Todo, pk=pk)
    if todo.completed:
        todo.mark_unresolved()
    else:
        todo.mark_resolved()
    return redirect('todo_list')
