import gradio as gr

with gr.Blocks(title='TodoListProject') as demo:
    gr.Markdown("# 📝 Your Todos (Django App)")
    gr.Markdown("Access the same Todo app interface as the web version")
    
    gr.HTML("""
    <iframe 
        src="http://127.0.0.1:8000" 
        style="width: 100%; height: 900px; border: 1px solid #ddd; border-radius: 8px;"
        sandbox="allow-same-origin allow-scripts allow-popups allow-forms allow-top-navigation"
        allow="same-origin"
    ></iframe>
    """)
    
    gr.Markdown("*The Django app is running on http://127.0.0.1:8000*")

if __name__ == '__main__':
    demo.launch(server_name='127.0.0.1', server_port=7860, share=False)




