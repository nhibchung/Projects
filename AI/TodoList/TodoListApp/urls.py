from django.urls import path
from . import views

urlpatterns = [
    path('', views.HomeView.as_view(), name='home'),
    path('todos/', views.TodoListView.as_view(), name='todo_list'),
    path('todos/create/', views.TodoCreateView.as_view(), name='todo_create'),
    path('todos/<int:pk>/edit/', views.TodoUpdateView.as_view(), name='todo_edit'),
    path('todos/<int:pk>/delete/', views.TodoDeleteView.as_view(), name='todo_delete'),
    path('todos/<int:pk>/toggle/', views.todo_toggle, name='todo_toggle'),
]
