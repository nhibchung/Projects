from django.db import models
from django.utils import timezone


class Todo(models.Model):
	title = models.CharField(max_length=200)
	description = models.TextField(blank=True)
	created_at = models.DateTimeField(auto_now_add=True)
	updated_at = models.DateTimeField(auto_now=True)
	due_date = models.DateField(null=True, blank=True)
	completed = models.BooleanField(default=False)

	class Meta:
		ordering = ['-created_at']

	def __str__(self):
		return self.title

	def mark_resolved(self):
		self.completed = True
		self.updated_at = timezone.now()
		self.save(update_fields=['completed', 'updated_at'])

	def mark_unresolved(self):
		self.completed = False
		self.updated_at = timezone.now()
		self.save(update_fields=['completed', 'updated_at'])
