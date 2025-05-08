/// @description 
#macro mx mouse_x
#macro my mouse_y
draw_set_halign(fa_center);

var button = function(_x, _y, _title, _on_click) {
	#macro button_width 120
	#macro button_heigh 25
	
	draw_set_color(c_white);
	draw_rectangle(_x, _y, _x+button_width, _y+button_heigh, false);
	draw_set_color(c_purple);
	draw_text(_x+button_width/2, _y+5, _title);
	
	if (mouse_check_button_pressed(mb_left) && point_in_rectangle(mx, my, _x, _y, _x+button_width, _y+button_heigh)) {
		_on_click();
	}
}

draw_set_color(c_white);
draw_text(room_width/2, 15, __link);
draw_text(room_width/2, 35, __filename);
button(20, 100, "set link", method(self, function() /*=>*/ {
    __link = get_string("link", __link);
}));

button(160, 100, "set filename", method(self, function() /*=>*/ {
    __filename = get_string("filename", __filename);
}));


button(20, 150, "start", method(self, function() /*=>*/ {
    download.start(__link, program_directory + __filename);
}));

var progress = download.get_progress();
var download_status = download.get_result();
var is_complete = download.is_complete();
draw_text(370, 160, string(progress));
draw_text(370, 180, string(download_status));
draw_text(370, 200, string("is complete {0}", is_complete));
draw_set_color(c_blue);
draw_line_width(150, 160, 350, 160, 6);
draw_set_color(c_green);
draw_line_width(150, 160, 150 + 200 * (progress/100), 160, 6);

