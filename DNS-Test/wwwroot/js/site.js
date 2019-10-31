// загрузим данные о дереве с сервера
var request = $.ajax({
	type: 'GET',
	url: 'api/tree',
});
// построим дерево после загрузки
request.done(function (data) {
	$(function () {
		$('#jstree').jstree({
			"core": {
				"mulitple": false,
				"animation": 500,
				"check_callback": function (operation, node, node_parent, node_position, more) {
					// запретим перемещать какой-либо элемент узла в файл
					if (operation == 'move_node' && node_parent.type == 'file') {
						return false;
					}
					// запретим перемещать какой-либо элемент узла без изменения родительского узла
					if (operation == 'move_node' && node_parent.id == node.parent) {
						return false;
					}
					return true;
				},
				"themes": {
					"dots": false
				},

				"data": data
			},

			"types": {
				"folder": {
					"icon": "/images/folder.png"
				},
				"file": {
					"icon": "/images/file.png"
				}
			},

			"plugins": [
				"dnd",
				"types",
				"unique",
				"changed",
				"sort"
			],
		// после обновления узла в дереве отправим на сервер данные для сохранения текущей структуры
		}).bind("move_node.jstree", function (event, data) {
			showProgressBar();

			var ajaxPost = $.ajax({
				type: 'POST',
				url: 'api/tree',
				data: { id: data.node.id, parentId: data.node.parent },
			});

			ajaxPost.done(function (data) {
				// Если от сервера получено true, значит данные были успешно сохранены
				if (data) {
					hideProgressBar();
				}
				else {
					$('#progressbar').html("Данные не обновлены, произошла ошибка");
				}
			});
		});
	});
})

function showProgressBar() {
	$("#jstree").hide();
	$('#progressbar').show();

	var valueProgressBar = 0;
	// сделаем 100 шагов, чтобы анимировать прогресс бар
	let timerId = setInterval(function () {
		valueProgressBar += 1;
		$('#progressbarline').css({
			"width": valueProgressBar + "%"
		});
	}, 5);
	// тайм-аут на работу прогресс бара
	setTimeout(function () {
		clearInterval(timerId);
	}, 500);
}

function hideProgressBar() {
	$('#progressbar').hide();
	$("#jstree").show();
}
