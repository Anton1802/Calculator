#!/usr/bin/python3

from kivy.app import App
from kivy.uix.widget import Widget


class Calculator(Widget):
    pass


class CalculatorApp(App):
    def build(self):
        return Calculator()


if __name__ == '__main__':
    CalculatorApp().run()
