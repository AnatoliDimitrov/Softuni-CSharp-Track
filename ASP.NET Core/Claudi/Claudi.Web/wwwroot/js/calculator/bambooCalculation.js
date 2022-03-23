﻿function calculate(model, color, width, height) {
	let colorCode = 0;	//default color
	let modelCode = 0; // default model
	let totalPrice = 0;
	
	let models = ["Ейша", "Феба"];
	let colors = ["J1", "J2", "J3", "J4", "J5", "J6",
		"B2", "B3", "B8", "B10", "D3", "D7", "D9", "D10", "D11",
		"B1", "B4", "B5", "B7", "B9", "B11", "B12", "B13", "D1", "D4", "D6", "D8",
		"B6", "D2", "D5"];

	let Coeficientbam = [1.00, 1.35, 1.75, 2.10];

	let eishaTable = [
		[44, 47, 48, 49, 52, 55, 57, 59, 60, 64, 68, 74, 78, 83, 87, 92, 98],
		[44, 47, 48, 49, 52, 55, 57, 62, 68, 73, 78, 83, 90, 95, 100, 105, 112],
		[44, 47, 48, 49, 52, 57, 64, 69, 77, 82, 90, 95, 101, 108, 114, 120, 127],
		[44, 47, 48, 49, 57, 64, 70, 78, 85, 92, 99, 105, 113, 120, 127, 134, 140],
		[44, 47, 48, 56, 62, 70, 78, 86, 94, 101, 109, 117, 125, 133, 139, 148, 155],
		[44, 47, 51, 60, 68, 77, 85, 94, 101, 111, 118, 127, 135, 144, 152, 161, 170],
		[44, 47, 56, 65, 74, 83, 92, 101, 111, 120, 130, 138, 148, 156, 166, 174, 185],
		[44, 49, 60, 69, 79, 91, 100, 111, 120, 130, 139, 150, 160, 169, 179, 189, 199],
		[44, 55, 64, 75, 86, 96, 108, 117, 129, 138, 150, 161, 170, 182, 191, 203, 213],
		[46, 57, 69, 81, 92, 103, 114, 126, 137, 148, 160, 170, 182, 195, 205, 217, 228],
		[48, 61, 74, 85, 98, 109, 121, 134, 146, 157, 169, 182, 195, 205, 218, 231, 242],
		[51, 65, 78, 91, 103, 116, 129, 140, 153, 168, 181, 192, 205, 218, 231, 243, 256],
		[56, 68, 82, 95, 109, 122, 135, 150, 164, 176, 190, 204, 217, 231, 244, 257, 272],
		[59, 73, 86, 100, 114, 129, 144, 157, 172, 186, 200, 215, 228, 243, 257, 272, 286],
		[61, 75, 91, 105, 120, 135, 151, 165, 181, 196, 209, 225, 241, 255, 270, 286, 300],
		[64, 79, 95, 111, 127, 143, 157, 173, 189, 204, 221, 237, 252, 268, 283, 300, 315],
		[66, 83, 99, 116, 133, 148, 165, 182, 198, 215, 231, 248, 263, 280, 296, 312, 329],
		[69, 86, 103, 121, 138, 155, 172, 189, 207, 224, 241, 257, 276, 293, 309, 326, 343],
		[73, 91, 108, 126, 144, 163, 179, 198, 216, 234, 251, 269, 287, 306, 322, 341, 359],
		[75, 94, 113, 131, 150, 168, 187, 205, 224, 242, 261, 280, 298, 316, 337, 355, 373],
		[78, 98, 117, 135, 155, 174, 195, 213, 233, 252, 272, 291, 309, 329, 348, 368, 386],
		[81, 100, 121, 140, 161, 182, 202, 221, 241, 261, 281, 302, 322, 342, 361, 381, 402]
	];

	let febaTable = [
		[47, 48, 51, 55, 56, 59, 61, 62, 65, 69, 74, 79, 85, 91, 95, 100, 105],
		[47, 48, 51, 55, 56, 59, 61, 66, 73, 78, 85, 91, 96, 101, 109, 114, 120],
		[47, 48, 51, 55, 56, 61, 68, 75, 81, 87, 95, 101, 108, 114, 121, 129, 135],
		[47, 48, 51, 55, 60, 68, 75, 82, 91, 98, 104, 112, 120, 127, 134, 143, 150],
		[47, 48, 51, 59, 66, 74, 82, 91, 99, 108, 114, 122, 131, 139, 148, 155, 164],
		[47, 48, 55, 62, 73, 81, 90, 99, 108, 116, 126, 134, 143, 152, 161, 169, 179],
		[47, 48, 59, 68, 78, 87, 96, 105, 116, 126, 135, 146, 155, 164, 173, 183, 192],
		[47, 52, 62, 74, 83, 94, 104, 114, 125, 135, 146, 155, 166, 176, 187, 198, 207],
		[47, 56, 66, 78, 90, 100, 112, 122, 134, 144, 155, 166, 178, 189, 200, 211, 222],
		[48, 60, 70, 83, 95, 108, 118, 130, 143, 153, 166, 178, 189, 202, 213, 224, 237],
		[51, 64, 75, 87, 100, 113, 126, 138, 151, 164, 176, 189, 202, 213, 225, 238, 251],
		[55, 66, 81, 94, 105, 120, 133, 147, 160, 173, 186, 199, 213, 225, 239, 252, 267],
		[57, 70, 85, 99, 113, 126, 139, 153, 168, 182, 196, 209, 224, 238, 252, 267, 280],
		[60, 74, 90, 103, 118, 133, 148, 163, 178, 191, 205, 221, 235, 251, 265, 280, 294],
		[62, 78, 94, 109, 125, 139, 155, 170, 186, 202, 217, 233, 248, 263, 278, 294, 309],
		[65, 81, 98, 113, 130, 146, 163, 178, 195, 209, 226, 242, 259, 274, 291, 307, 324],
		[68, 85, 101, 118, 135, 152, 169, 186, 203, 220, 237, 254, 270, 287, 304, 321, 338],
		[70, 90, 105, 125, 140, 160, 176, 195, 211, 230, 246, 265, 281, 300, 316, 335, 351],
		[74, 92, 111, 129, 147, 165, 183, 202, 220, 239, 257, 276, 294, 312, 330, 348, 367],
		[77, 96, 114, 134, 152, 172, 191, 209, 230, 248, 268, 286, 306, 324, 343, 363, 381],
		[79, 99, 118, 139, 160, 179, 199, 218, 238, 257, 277, 296, 316, 337, 356, 376, 395],
		[82, 103, 125, 144, 165, 185, 205, 225, 246, 268, 287, 308, 328, 348, 371, 390, 411]
	];

	getColor();
	getModel();
	let error = CheckBoundories(modelCode, width, height);
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

	function CheckBoundories(model, width, height) {
		let errMSG = "Зададените размери са извън позволената ширина/височина на продукта";
		let J1ErrEisha = "За бамбук J1, J2, J3, J4, J5 и J6 (за система Ейша) максималната ширина е 200 см.";
		let B3ErrEisha = "За бамбук B3, B4, B5 и B6 (за система Ейша) максималната височина е 200 см.";
		let J1ErrFeba = "За бамбук J2, J5 и J6 (система Феба) максималната ширина е 180 см.";
		let B3ErrFeba = "За бамбук B3, B4, B5, ,B6, B7, B13 и D4 (система Феба) максималната ширина е 180 см.";
		let sqrtMeters = width * height / 10000;

		switch (model) {
			case 0:
				if (width > 200 || width < 35 || height > 250 || height < 40 || sqrtMeters > 5) {
					return errMSG;
				}
				else if (colorCode < 6) {
					if (width > 180) {
						return J1ErrEisha;
					}
				}
				else if (colorCode == 7 || colorCode == 16 || colorCode == 17 || colorCode == 18) {
					if (height > 200) {
						return B3ErrEisha;
					}
				}
				break;

			case 1:
				if (width > 200 || width < 35 || height > 250 || height < 40 || sqrtMeters > 4) {
					return errMSG;
				}
				else if (colorCode == 1 || colorCode == 4 || colorCode == 5) {
					if (width > 200) {
						return J1ErrFeba;
					}
				}
				else if (colorCode == 7 || colorCode == 16 || colorCode == 17 || colorCode == 18 || colorCode == 22 || colorCode == 24) {
					if (width > 200) {
						return B3ErrFeba;
					}
				} break;
		}
	}

	function printFinalPrice(error) {
		if (error !== undefined) {
			return error
		}

		let discount = 6;	//precent discount
		let colorGroup = 0;
		let colorExeptionMSG = "Бамбук J1, J3 и J4 не може да се изпълняват със система Феба.";

		CheckBoundories(modelCode, width, height);

		width = convertSize(width);
		height = convertSize(height);

		switch (modelCode) {
			case 0:
				totalPrice = eishaTable[height][width];
				break;

			case 1:
				totalPrice = febaTable[height][width];

				if (colorCode == 0 || colorCode == 2 || colorCode == 3) {
					alert(colorExeptionMSG);
				} break;
		}

		if (colorCode > 26) {
			colorGroup = 3;
		}
		else if (colorCode > 14) {
			colorGroup = 2;
		}
		else if (colorCode > 5) {
			colorGroup = 1;
		}
		else {
			colorGroup = 0;
		}

		totalPrice *= Coeficientbam[colorGroup];
		totalPrice -= totalPrice * (discount / 100);

		return totalPrice;
	}
}

export default {
    calculate,
}