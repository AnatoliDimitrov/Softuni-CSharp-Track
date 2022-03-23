﻿function calculate(model, color, width, height, driving) {
	let models = ["Елеганте", "Аура"];
	let colors = [
		"cesta(29**)",
		"rioja(C20)",
		"golfo(19**)",
		"monarca(B30)",
		"cuisine(B31)", //group 0 from 0 - 4

		"vereda(B1**)",
		"vanesa(B2*)",
		"brest(39**)",
		"sunset(B61*)",
		"altea(B40*)",
		"jacquard(13**)",//group 1 from 5 - 10

		"cotton(20**)",
		"mimos(C4***)",
		"veronika(49**)"]; //group 0 from 11 - 12

	let coeficients =
		[
			[1, 1.1, 1.25],
			[1, 1.1, 1.25]
		];

	let colorCode = 0;	//default color
	let modelCode = 0; // default model
	let totalPrice = 0;



	let stillTable = [
		[55, 64, 73, 80, 90, 98, 108, 115, 124, 132, 142, 149],
		[57, 66, 75, 84, 93, 103, 111, 123, 130, 138, 148, 158],
		[59, 70, 77, 88, 98, 107, 115, 126, 135, 142, 155, 164],
		[64, 76, 84, 95, 107, 114, 125, 138, 143, 153, 166, 175],
		[66, 77, 88, 98, 110, 117, 130, 141, 149, 160, 173, 183],
		[73, 84, 93, 107, 116, 128, 139, 151, 161, 172, 185, 195],
		[75, 86, 97, 109, 123, 132, 142, 158, 166, 176, 192, 200],
		[76, 89, 100, 111, 125, 135, 148, 163, 173, 183, 198, 208],
		[80, 95, 107, 117, 134, 143, 159, 172, 183, 193, 209, 222],
		[83, 98, 109, 123, 138, 148, 163, 176, 189, 199, 216, 227],
		[88, 105, 115, 130, 145, 159, 172, 188, 198, 209, 227, 239],
		[90, 108, 117, 133, 148, 163, 175, 192, 202, 217, 234, 248],
		[92, 109, 123, 138, 153, 165, 178, 197, 209, 224, 242, 255],
		[98, 114, 128, 142, 161, 174, 190, 207, 222, 233, 252, 265],
		[100, 116, 132, 147, 165, 177, 195, 214, 226, 239, 259, 275],
		[105, 124, 139, 153, 173, 189, 202, 223, 235, 250, 273, 285],
		[108, 126, 141, 159, 176, 192, 208, 227, 243, 258, 278, 292]
	];

	let maxiStilTable = [
		[67, 74, 80, 92, 100, 108, 113, 120, 133, 139, 145, 153, 159, 172, 177, 183, 190, 197, 210, 216, 223, 232, 236, 247],
		[70, 77, 83, 95, 103, 110, 117, 125, 138, 145, 150, 159, 166, 178, 184, 191, 198, 205, 216, 226, 234, 240, 245, 260],
		[73, 80, 86, 101, 108, 116, 125, 132, 147, 151, 159, 168, 177, 190, 197, 205, 211, 217, 233, 242, 248, 257, 264, 277],
		[74, 82, 90, 103, 110, 123, 127, 135, 150, 157, 165, 176, 182, 197, 205, 213, 217, 226, 241, 249, 260, 266, 275, 286],
		[77, 84, 92, 108, 116, 126, 135, 145, 158, 166, 175, 184, 192, 209, 216, 224, 234, 241, 255, 266, 275, 282, 292, 307],
		[78, 86, 95, 110, 117, 132, 139, 148, 163, 172, 180, 191, 199, 214, 223, 233, 241, 248, 264, 276, 283, 292, 301, 315],
		[82, 91, 100, 114, 125, 138, 147, 155, 172, 180, 190, 201, 211, 226, 236, 243, 252, 264, 278, 291, 300, 309, 318, 334],
		[83, 92, 103, 117, 127, 140, 150, 159, 176, 184, 195, 209, 216, 234, 242, 251, 263, 270, 286, 300, 309, 318, 328, 345],
		[84, 95, 107, 124, 133, 148, 157, 167, 183, 195, 205, 216, 230, 243, 255, 265, 276, 284, 302, 315, 326, 335, 347, 364],
		[86, 97, 109, 126, 135, 150, 159, 172, 189, 199, 210, 223, 235, 249, 263, 274, 283, 295, 310, 325, 334, 347, 358, 374],
		[90, 101, 111, 132, 142, 157, 167, 178, 197, 209, 217, 234, 243, 264, 275, 284, 298, 308, 326, 340, 350, 363, 375, 392],
		[91, 105, 114, 133, 147, 159, 172, 183, 201, 213, 224, 240, 249, 268, 280, 295, 303, 315, 334, 349, 361, 374, 384, 401],
		[93, 108, 117, 138, 150, 166, 178, 190, 210, 222, 235, 248, 263, 280, 295, 307, 317, 330, 349, 365, 376, 390, 401, 420],
		[95, 109, 123, 140, 153, 168, 182, 195, 214, 226, 240, 255, 267, 286, 300, 311, 326, 338, 360, 374, 386, 398, 411, 433],
		[100, 111, 126, 147, 159, 176, 189, 202, 222, 236, 248, 265, 278, 299, 311, 326, 340, 351, 374, 390, 401, 415, 430, 450],
		[101, 113, 127, 149, 163, 178, 192, 207, 226, 241, 255, 270, 284, 307, 318, 333, 348, 361, 382, 398, 411, 426, 439, 461],
		[103, 116, 128, 151, 166, 182, 197, 211, 233, 245, 261, 277, 292, 311, 327, 341, 357, 367, 391, 408, 420, 435, 450, 470],
		[105, 120, 134, 157, 172, 189, 202, 217, 240, 255, 268, 286, 301, 325, 338, 353, 367, 383, 405, 422, 436, 452, 466, 491],
		[107, 123, 138, 158, 175, 191, 209, 222, 243, 261, 275, 295, 308, 330, 347, 361, 376, 391, 413, 433, 447, 463, 476, 499],
		[109, 125, 140, 163, 178, 198, 214, 232, 251, 267, 283, 302, 318, 341, 358, 374, 390, 405, 430, 447, 463, 477, 495, 518],
		[110, 126, 145, 166, 182, 201, 217, 235, 257, 275, 291, 309, 326, 349, 365, 382, 397, 414, 436, 458, 472, 491, 503, 527],
		[113, 132, 148, 172, 189, 209, 224, 241, 266, 282, 300, 318, 335, 361, 377, 393, 411, 428, 452, 472, 491, 503, 523, 548]
	];

	getColor();
	getModel();
	let error = checkBounderies(modelCode, width, height);
	return printFinalPrice(error);

	function convertSize(arg, deviation) {
		let local = Math.round(Math.ceil(arg) / 10);

		local = local - deviation;

		if (local < 0) {
			local = 0;
		}
		return local;
	}

	function getColor() {
		colorCode = colors.indexOf(color);
	}

	function getModel() {
		modelCode = models.indexOf(model);
	}

	function checkBounderies(model, w, h) {

		let errMSG = "Зададените размери са извън позволената ширина/височина на продукта";
		if (model == 0) {
			if (w < 30 || w > 150 || h < 30 || h > 250) {
				return errMSG;
			}
			if ((w * h) / 10000 > 4) {
				return "Зададените размери са извън позволената квадратура на продукта";
			}
		}
		if (model == 1) {
			if (w < 40 || w > 270 || h < 40 || h > 300) {
				return errMSG;
			}
		}

	}

	function printFinalPrice(error) {
		if (error !== undefined) {
			return error
		}

		let discount = 6;	//precent discount
		let K = 0;	// multiplier

		checkBounderies(modelCode, width, height);

		width = convertSize(width, 4);
		height = convertSize(height, 6);
		if (height < 0) {
			height = 0;
		}


		switch (modelCode) {
			case 0:
				totalPrice = stillTable[height][width];
				break;

			case 1:
				totalPrice = maxiStilTable[height][width];
				break;
		}

		switch (colorCode) {
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
				K = 0;
				break;
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
				K = 1;
				break;
			case 11:
			case 12:
			case 13:
				K = 2;
				break;
		}

		totalPrice *= coeficients[modelCode][K];
		if ((driving == 1) && (modelCode == 0)) {
			totalPrice += 7;
		}
		if ((driving == 1) && (modelCode == 1)) {
			totalPrice += 16.9;
		}

		totalPrice -= totalPrice * (discount / 100);

		return totalPrice;
	}
}

export default {
    calculate,
}