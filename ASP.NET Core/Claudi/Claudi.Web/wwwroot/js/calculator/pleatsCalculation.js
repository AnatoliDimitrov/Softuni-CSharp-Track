﻿function calculate(model, color, width, height) {
	let colorCode = 0;	//default color
	let modelCode = 0; // default model
	let totalPrice = 0;

	let models = ["BB 10", "BB 15", "BB 30", "AO 10", "AO 30", "AO 70", "BF 50", "BF 51",
		"BB 20", "BB 24", "AO 20", "BO 10", "BO 75", "BB 40", "AO 40"];

	let colors = [
		"Crepe FR",
		"Tendence",
		"Flush",
		"Venezia",
		"life", //group 0 from 0 - 4

		"Crepe Topar FR",
		"Juno",
		"Crush Pearl FR",
		"Porto",
		"Blossom",//group 1 from 5 - 9

		"California",
		"Onda",
		"Scala BO Color", //group 2 from 10 - 12

		"Duette Fixe Relife",
		"Crush DustBlock",
		"Georgette",
		"Duette Unix Duotone", //group3 from 13 - 16

		"Crush Topar Plus",
		"Duette Classic 25mm BO", //group 4 from 17 - 18

		"Ardeche",
		"Duette Fixe 25mm BO"];//group 5 from 19 - 20

	let pliseTable10 = [
		[59, 65, 74, 83, 90, 98, 105, 113, 123, 129, 139, 145, 152, 162, 173, 178, 185, 194, 203],
		[59, 68, 74, 83, 92, 107, 113, 123, 133, 140, 145, 154, 164, 173, 179, 188, 198, 205, 212],
		[68, 74, 83, 92, 100, 107, 115, 133, 140, 147, 157, 164, 174, 180, 198, 207, 213, 219, 232],
		[68, 75, 83, 100, 108, 115, 125, 140, 147, 157, 167, 175, 189, 199, 208, 222, 233, 242, 247],
		[68, 83, 92, 100, 108, 125, 134, 142, 157, 167, 175, 189, 199, 208, 224, 233, 242, 248, 265],
		[75, 84, 93, 108, 118, 127, 142, 149, 159, 177, 184, 190, 209, 215, 234, 243, 249, 265, 275],
		[75, 84, 100, 108, 120, 135, 143, 159, 168, 184, 194, 203, 215, 225, 244, 250, 267, 277, 294],
		[75, 93, 102, 118, 127, 143, 150, 168, 178, 194, 203, 217, 229, 244, 250, 269, 279, 294, 302],
		[77, 93, 102, 120, 128, 143, 160, 172, 185, 197, 210, 219, 239, 252, 263, 279, 289, 303, 313],
		[84, 93, 109, 120, 138, 150, 162, 178, 197, 205, 219, 232, 247, 263, 273, 289, 307, 314, 329],
		[84, 102, 109, 128, 144, 160, 173, 185, 198, 212, 232, 247, 255, 274, 289, 299, 314, 332, 342],
		[87, 102, 120, 138, 144, 162, 179, 197, 207, 222, 240, 255, 274, 282, 299, 315, 332, 343, 360],
		[87, 104, 122, 138, 152, 173, 179, 198, 213, 233, 248, 257, 275, 293, 310, 325, 343, 352, 368],
		[94, 109, 122, 139, 154, 174, 188, 207, 222, 242, 257, 265, 293, 300, 317, 335, 352, 369, 385],
		[94, 110, 129, 145, 164, 180, 198, 213, 233, 248, 265, 277, 300, 317, 335, 352, 369, 378, 397],
		[94, 110, 129, 145, 164, 180, 199, 214, 234, 249, 267, 284, 312, 328, 337, 363, 379, 390, 405],
		[104, 122, 139, 154, 174, 189, 208, 224, 243, 258, 277, 295, 318, 337, 353, 370, 390, 405, 424],
		[104, 122, 139, 154, 175, 199, 214, 234, 250, 269, 285, 303, 328, 348, 364, 380, 399, 425, 443],
		[104, 123, 140, 164, 180, 202, 215, 243, 260, 279, 295, 313, 338, 357, 372, 394, 415, 433, 0],
		[105, 129, 145, 167, 182, 209, 225, 244, 260, 285, 303, 320, 348, 367, 382, 409, 428, 445, 0],
		[110, 133, 147, 175, 190, 215, 237, 250, 273, 295, 314, 332, 359, 374, 402, 417, 435, 0, 0],
		[110, 133, 147, 175, 190, 215, 239, 252, 280, 298, 320, 342, 360, 384, 403, 429, 0, 0, 0]
	];

	let pliseTable20 = [
		[75, 90, 98, 105, 122, 128, 135, 149, 158, 167, 173, 188, 197, 209, 215, 224, 240, 247, 255],
		[83, 92, 98, 112, 123, 135, 143, 149, 159, 174, 179, 189, 205, 210, 225, 233, 247, 257, 263],
		[83, 92, 107, 112, 128, 138, 150, 159, 168, 180, 189, 205, 212, 228, 234, 248, 257, 264, 279],
		[84, 98, 107, 123, 129, 143, 159, 168, 175, 190, 205, 212, 228, 237, 248, 264, 274, 289, 295],
		[92, 100, 113, 123, 138, 150, 160, 175, 180, 198, 212, 222, 237, 249, 260, 274, 289, 297, 312],
		[92, 107, 113, 129, 139, 154, 169, 175, 190, 207, 213, 229, 244, 250, 267, 282, 298, 303, 318],
		[92, 107, 123, 129, 144, 160, 175, 182, 199, 213, 223, 239, 250, 267, 277, 293, 307, 320, 330],
		[100, 108, 124, 139, 154, 169, 177, 192, 208, 223, 239, 245, 262, 277, 293, 307, 320, 330, 344],
		[100, 113, 124, 139, 154, 169, 182, 202, 208, 232, 240, 255, 269, 283, 299, 314, 330, 337, 352],
		[100, 113, 133, 145, 162, 177, 192, 202, 214, 232, 247, 263, 278, 294, 309, 325, 338, 357, 369],
		[100, 115, 133, 145, 162, 184, 194, 209, 224, 240, 257, 273, 294, 300, 315, 338, 357, 364, 378],
		[108, 124, 139, 157, 172, 184, 202, 215, 233, 247, 263, 279, 300, 317, 333, 348, 364, 379, 397],
		[108, 124, 140, 157, 172, 194, 209, 224, 242, 257, 273, 289, 302, 328, 342, 359, 370, 390, 403],
		[108, 125, 140, 164, 178, 194, 210, 233, 248, 264, 279, 297, 317, 334, 349, 365, 390, 403, 419],
		[115, 133, 145, 164, 188, 203, 215, 234, 257, 274, 289, 303, 328, 343, 360, 380, 398, 413, 430],
		[115, 133, 147, 172, 188, 210, 225, 242, 258, 280, 297, 313, 334, 350, 367, 392, 404, 424, 443],
		[115, 134, 157, 173, 197, 210, 228, 248, 265, 290, 303, 318, 343, 362, 374, 399, 424, 437, 453],
		[115, 140, 158, 178, 197, 217, 234, 258, 275, 297, 313, 329, 350, 374, 394, 413, 432, 445, 469],
		[125, 140, 158, 179, 205, 217, 243, 260, 275, 298, 320, 335, 362, 377, 400, 425, 438, 464, 0],
		[125, 140, 164, 188, 205, 228, 249, 265, 282, 307, 330, 344, 368, 394, 408, 433, 455, 470, 0],
		[125, 147, 167, 189, 212, 237, 249, 275, 293, 314, 337, 352, 377, 400, 415, 447, 465, 0, 0],
		[125, 147, 173, 189, 212, 237, 260, 277, 299, 325, 337, 363, 384, 402, 428, 448, 0, 0, 0]
	];

	let Coeficient = [1.00, 1.10, 1.30, 1.40, 1.60, 2.10];

	getColor();
	getModel();
	let error = checkBoundories();
	return printFinalPrice(error);

	function getColor() {
		colorCode = colors.indexOf(color);
	}

	function getModel() {
		modelCode = models.indexOf(model);
	}

	function convertSize(arg) {
		let local = Math.round(Math.ceil(arg) / 10);

		local = local - 4;

		if (local < 0) {
			local = 0;
		}
		return local;
	}

	function checkBoundories() {
		if (width > 220 || width < 20 || height > 250 || height < 20) {
			return "Зададените размери са извън позволената ширина/височина на продукта";
		}
	}

	function printFinalPrice(error) {
		if (error !== undefined) {
			return error
		}

		let errMSG = "Зададените размери са извън позволената ширина/височина на продукта";
		let discount = 6;	//precent discount

		checkBoundories(modelCode, width, height);

		width = convertSize(width);
		height = convertSize(height);

		if (modelCode < 8) {
			totalPrice += pliseTable10[height][width];
			if (totalPrice == 0) {
				return errMSG;
			}
		}
		else {
			totalPrice += pliseTable20[height][width];
			if (totalPrice == 0) {
				return errMSG;
			}
		}

		let group;
		switch (colorCode) {
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
				group = 0;
				break;
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
				group = 1;
				break;
			case 10:
			case 11:
			case 12:
				group = 2;
				break;
			case 13:
			case 14:
			case 15:
			case 16:
				group = 3;
				break;
			case 17:
			case 18:
				group = 4;
				break;
			case 19:
			case 20:
				group = 5;
				break;
			default:
				group = 7;
				break;
		}

		totalPrice *= Coeficient[group];

		totalPrice -= totalPrice * (discount / 100);

		return totalPrice;
	}
}

export default {
	calculate,
}