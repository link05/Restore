import { useSelect } from "@mui/base";
import { configureStore } from "@reduxjs/toolkit";
import { TypedUseSelectorHook, useDispatch, useSelector } from "react-redux";
import { basketSlice } from "../../features/basket/basketSlice";
import { counterSlice } from "../../features/contact/counterSlice";


//list all slices here
export const store = configureStore({
    //reducers contain state and methods that update the states
    reducer: {
        counter: counterSlice.reducer,
        basket: basketSlice.reducer
    }
})

export type RootState = ReturnType<typeof store.getState>; //state
export type AppDispatch = typeof store.dispatch; //dispatch

//methods used by components to get/modify states
export const useAppDispatch = () => useDispatch<AppDispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;