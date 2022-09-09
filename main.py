#!/usr/bin/python3

from kivy.app import App
from kivy.uix.widget import Widget
from kivy.config import Config
from kivy.uix.popup import Popup
from kivy.uix.label import Label
from kivy.uix.scrollview import ScrollView


Config.set('graphics', 'resizable', 0)
Config.set('graphics', 'width', 400)
Config.set('graphics', 'height', 500)


class Calculator(Widget):

    formula = ''
    result = 0
    history = []

    def formula_add(self, text, visual=''):
        if visual != '':
            self.input.text += visual
        else:
            self.input.text += text
        self.formula += text

    def start_operation(self):
        try:
            self.result = eval(self.formula)
            self.add_history(self.formula, self.result)
        except SyntaxError:
            self.input.text = "Error"

        if self.result != 0:
            self.input.text = str(self.result)
            self.formula = str(self.result)
        else:
            self.input.text = "Error"

    def reset(self):
        self.input.text = ''
        self.result = 0
        self.formula = ''

    def clear(self):
        str_list = []
        str = self.input.text
        str_list = list(str)
        formula_list = []
        formula = self.formula
        formula_list = list(formula)

        for symbol in str_list:
            if symbol == '%':
                self.input.text = self.input.text.translate
                ({ord(i): None for i in '/100'})
                self.formula = self.formula.translate
                ({ord(i): None for i in '/100'})
        try:
            self.input.text = self.input.text.replace(str_list.pop(), '', 1)
            self.formula = self.formula.replace(formula_list.pop(), '', 1)
        except IndexError:
            self.input.text = ""
            self.formula = ""

    def add_history(self, formula, result):
        self.history.append(f"{self.input.text}={self.result}")

    def show_history(self):
        scrollview = ScrollView(do_scroll_x=False, do_scroll_y=True)
        content = Label(text="\n".join(self.history),
                        font_size='20sp', size_hint_y=None)
        scrollview.add_widget(content)
        popup = Popup(title='History', content=scrollview,
                      size=(400, 400), size_hint=(None, None))
        popup.open()


class CalculatorApp(App):
    def build(self):
        return Calculator()


if __name__ == '__main__':
    CalculatorApp().run()
