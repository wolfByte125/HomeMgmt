import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { BASE_URL, ENDPOINTS } from "../../constants/apiConstants";

export const apiSlice = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({ baseUrl: BASE_URL }),
  tagTypes: ["Users"],
  endpoints: (builder) => ({
    // USER ENDPOINTS

    getUsers: builder.query({
      query: () => ENDPOINTS.GET_USERS,
      transformResponse: (res) => res.sort((a, b) => b.id - a.id),
      providesTags: ["Users"],
    }),

    createUser: builder.mutation({
      query: (newUser) => ({
        url: ENDPOINTS.ADD_USER,
        method: "POST",
        body: newUser,
      }),
      invalidatesTags: ["Users"],
    }),

    updateUser: builder.mutation({
      query: (user) => ({
        url: ENDPOINTS.UPDATE_USER + user.id,
        method: "PATCH",
        body: user,
      }),
      invalidatesTags: ["Users"],
    }),

    deleteUser: builder.mutation({
      query: ({ id }) => ({
        url: ENDPOINTS.DELETE_USER + id,
        method: "DELETE",
      }),
      invalidatesTags: ["Users"],
    }),

    //OTHER ENDPOINTS
  }),
});

export const {
  useGetUsersQuery,
  useCreateUserMutation,
  useUpdateUserMutation,
  useDeleteUserMutation,
} = apiSlice;
