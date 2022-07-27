import { configureStore } from "@reduxjs/toolkit";
import { hospitalApi } from "service/HospitalService";

export const store = configureStore({
  reducer: {
    [hospitalApi.reducerPath]: hospitalApi.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({ serializableCheck: false }).concat(
      hospitalApi.middleware
    ),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
