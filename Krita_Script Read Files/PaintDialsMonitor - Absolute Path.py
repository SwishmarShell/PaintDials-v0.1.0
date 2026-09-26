from krita import *
from PyQt5.QtCore import QObject, QTimer

import json
import os

COMMAND_PATH = r"C:\Users\TAHATA\Documents\PaintDials\Command.json"


class PaintDialsMonitor(QObject):

	def __init__(self):
		super().__init__()

		self.last_time = 0

		self.timer = QTimer()

		self.timer.timeout.connect(
		self.check_json
		)

		self.timer.start(200)

		print(
			"PaintDials Monitor Started"
		)

	def check_json(self):

		try:

			if not os.path.exists(
				COMMAND_PATH
			):
				return

			current_time = os.path.getmtime(
				COMMAND_PATH
			)

			if current_time == self.last_time:
				return

			self.last_time = current_time

			with open(
				COMMAND_PATH,
				"r",
				encoding="utf-8"
			) as f:

				data = json.load(f)

			view = (
				Krita.instance()
				.activeWindow()
				.activeView()
			)

			if not view:
				return

			view.setBrushSize(
				data["Size"]
			)

			view.setPaintingOpacity(
				data["Opacity"]
			)

			print(
				f'Applied '
				f'Size={data["Size"]} '
				f'Opacity={data["Opacity"]}'
			)

		except Exception as ex:

			print(
				"PaintDials Error:",
				ex
			)


monitor = PaintDialsMonitor()
