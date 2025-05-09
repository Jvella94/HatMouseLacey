MODE?=GOG
GAME_DIR=${HOME}/GOG Games/Stardew Valley/game
ifeq (${MODE}, steam)
	GAME_DIR=${HOME}/.steam/steam/steamapps/common/Stardew Valley
endif
MOD_DIR_CP=${GAME_DIR}/Mods/HatMouseLacey
MOD_DIR_SMAPI=${GAME_DIR}/Mods/HatMouseLacey_Core

install: smapi cp

smapi:
	cd SMAPI && MODE=${MODE} dotnet build /clp:NoSummary
	install -d "${MOD_DIR_SMAPI}/data"
	install -m 644 SMAPI/data/*.json "${MOD_DIR_SMAPI}/data/"
	install -m 644 LICENSE "${MOD_DIR_SMAPI}/"

cp:
	mkdir -p "${MOD_DIR_CP}"
	install -m 644 CP/content.json CP/manifest.json "${MOD_DIR_CP}/"
	/bin/cp -r CP/assets CP/compat CP/data CP/i18n "${MOD_DIR_CP}/"
	install -m 644 LICENSE "${MOD_DIR_CP}/"
	install -m 644 docs/nonlicensed.txt "${MOD_DIR_CP}/"

palettes: source/tint
	$< "source/house.png" CP/assets/house
	$< "source/storefront.png" CP/assets/house
	$< "source/FairStall/hatmouselaceyStall.png" CP/assets/maps
	@for lang in de es fr hu it ja ko pt ru tr zh; do \
		echo "$< \"source/FairStall/stallText_$$lang.png\" \"source/FairStall/stallText-palettes.txt\" CP/assets/locale"; \
		$< "source/FairStall/stallText_$$lang.png" "source/FairStall/stallText-palettes.txt" CP/assets/locale; \
	done
	$< "source/hatmouselaceyInterior.png" CP/assets/maps
	$< "source/ellehouse.png" CP/assets/textures
	$< "source/ellestorefront.png" CP/assets/textures
	$< "source/Furniture.png" CP/assets/items

source/tint: source/tint.c
	${CC} -o $@ $< -lpng

clean:
	rm -rf SMAPI/bin SMAPI/obj

uninstall:
	rm -rf "${MOD_DIR_CP}" "${MOD_DIR_SMAPI}"
