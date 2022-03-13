function calculate(model, color, group, width, height) {
	var selectedVerticalType;
	//Gettign values ffrom sizes form for Horizontals and Verticals and Prints the result
	var colorCodevs = 0;	//default color
	var modelCode = 0; // default model
	var totalPrice = 0;
	var selctedVerical = 0;
	var selctedVerical = 0;

	// Vertical MODELS ----------------------------
	var verticalModels = ["89 мм", "127 мм", "AL 89"];
	// VEtical COLORS
	var verticalColors = [
		["Rococo (12**)",
			"Polly (94**)",
			"Beata (96**)",
			"Melisa (15**)",
			"Moon (35*)",
			"Vanessa (55**)",
			"Sandra (82**)",
			"Jenny (92**)",
			"Ray (34*)",
			"Van Gogh (45**)",
			"Silk (21**)",
			"Pasifico (115***)",
			"Lima (56*****)",
			"Melisa BO (54**) BlackOut",
			"Metalic (57*****)",
			"Lumina (255****)",
			"Guardian (720**)",
			"Juno (97****)",
			"Tundra (759**)",
			"Porto(51****)",
			"Albery (757**)",
			"Carina BO (102****) BlackOut",
			"Jacquard Natalie (085****)",
			"Banbury (728**)",
			"Strata SPC (715**)",
			"Juno BO (112****) BlackOut",
			"Monterey (756**)",
			"Blossom Print (741**)",
			"Green Screen ECO (965****)",
			"Oslo (729**)",
			"Monroe (758**)",
			"Jacquard Cube (695****)",
			"Hampton (736**)",],	//89
		["Corra(50**)",
			"Creppe(51**)",
			"Jenny(97**)",
			"Shantung(SH**)",
			"Fiesta(52**)",
			"Vanesa(57**)",
			"Ray(66**)",
			"Aneta(65**)",
			"Itaca(14**)",
			"Van Gogh(69**)",
			"Patricia(19**)",
			"Mountain(74**)",
			"Carina BlackOut(578****)",
			"Screen(10***)",
			"Green Screen ECO(960****)"],	//127
		["Бяла(0150)",
			"Слонова кост(4459)",
			"Сребриста(7113)",
			"Сива(7010)",
			"Крем(4451)",
			"Мед(7418)",
			"Бяла перф.(0150P)",
			"Черна перф.(1858P)",
			"Слонова кост перф.(4459P)",
			"Сребриста перф.(7113P)",
			"Сива перф.(7010P)",
			"Крем перф.(4451P)"]	//AL
	];

	var verticalTable = [
		[10.44, 11.16, 12.72, 12.72, 13.08, 13.56, 13.56, 13.80, 13.80, 13.80, 15.00, 21.24, 25.08, 26.28, 29.16, 32.76, 32.76, 36.60, 38.28, 41.88, 43.80, 43.80, 49.08, 49.08, 49.08, 50.28, 50.28, 57.48, 59.40, 61.09, 62.29, 68.29, 71.86],	// 89mm
		[10.44, 11.16, 13.08, 12.49, 13.80, 14.28, 14.28, 16.68, 16.68, 16.68, 20.28, 39.59, 43.80, 50.28, 57.48],	//127mm
		[58, 63, 59, 88, 59, 88, 59, 88, 59, 88, 59, 88, 89, 37, 93, 13, 93, 13, 93, 13, 93, 13, 93, 13]	//AL
	]

	//Prints an option TAG whit argument gived
	function printElement(array, index) {
		document.write(array[index]);
	}

	function getVerticalType(model) {

		$('#selectColorvs').find('option').remove();
		var type = model.selectedIndex;
		option = verticalColors[type];
		for (var i = 0; i < option.length; i++) {
			$('#selectColorvs').append("<option value=" + 'option[i]' + ">" + option[i] + "</option>");
		}
	}


	function getColor(color) {
		colorCodevs = verticalColors.indexOf(color.toLowerCase());
	}

	function getModel(model) {
		modelCode = model.selectedIndex;	//models are the rows in  horizontalTable
		selctedVerical = model;
	}

	// checkes the width and hitght
	function checkBoundoriesvs(model, width, height) {
		var errorMSG = "Зададените размери са извън позволената ширина/височина на продукта";
		var errorMSG_ = "Зададените размери са извън позволената площ на продукта";

		switch (model) {
			case 0:
			case 2:
			case 1:
				if (width < 20 || width > 600 || height < 20 || height > 500) {
					alert(errorMSG);
				} break;
		}

		if ((width * height) / 10000 > 20) {
			alert(errorMSG_);
		}
	}

	function printFinalPrice(fromModels) {
		var sizeWidth = document.getElementById("sunblindWidthvs").value;
		var sizeHeight = document.getElementById("sunblindHeightvs").value;
		var squareMeters;
		var pricePerSquareMeter = 0;
		var discount = 6;	//precent discount
		var colorGroup;

		squareMeters = sizeWidth * sizeHeight / 10000;
		if (squareMeters < 0.5) {
			squareMeters = 0.5;
		}
		// checking the boundories

		checkBoundoriesvs(modelCode, sizeWidth, sizeHeight);

		pricePerSquareMeter = fromModels[modelCode][colorCodevs];
		totalPrice = totalPrice + (squareMeters * pricePerSquareMeter);
		totalPrice = totalPrice + (25.08 * sizeWidth / 100);
		totalPrice -= totalPrice * (discount / 100);

		if (totalPrice == 0) {
			totalPrice = "Неподдържан цвят за този модел";
			document.getElementById("finalPricevs").innerHTML = totalPrice;
		}
		else {
			document.getElementById("finalPricevs").innerHTML = totalPrice.toFixed(2) + " лв.";
		}
		totalPrice = 0;
		return false;
	}
}

export default {
    calculate,
}